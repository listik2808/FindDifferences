using Scripts.Services;
using Scripts.Services.SaveLoad;
using System;
using System.Collections.Generic;

namespace Scripts.Infrastructure
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _state;
        private IExitableState _activeState;

        public GameStateMachine(SceneLoader sceneLoader,AllServices services) 
        {
            _state = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstarapState)] = new BootstarapState(this,sceneLoader,services),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, services.Single<IGameFactory>(),services.Single<IPersistenProgressServices>()),
                [typeof(LoadProgressState)] = new LoadProgressState(this,services.Single<IPersistenProgressServices>(),services.Single<ISaveLoadService>()),
                [typeof(GameLoopState)] = new GameLoopState(this),
            };
        }

        public void Enter<TState>() where TState :class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayLoad>(TPayLoad payLoad) where TState : class, IPayLoadState<TPayLoad>
        {
            TState state = ChangeState<TState>();
            state.Enter(payLoad);
        }

        public void Enter<TState,TPayLoad, TPayLoadInt>(TPayLoad payLoad, TPayLoadInt namberLevel) where TState : class, IPayLoadStateLevel<TPayLoad, TPayLoadInt>
        {
            TState state = ChangeState<TState>();
            state.Enter(payLoad,namberLevel);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();

            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState =>
            _state[typeof(TState)] as TState;
    }
}
