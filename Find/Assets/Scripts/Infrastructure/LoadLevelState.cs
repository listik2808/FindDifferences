using Scripts.Services;
using UnityEngine;

namespace Scripts.Infrastructure
{
    public class LoadLevelState : IPayLoadStateLevel<string, int>
    {

        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;
        private readonly IPersistenProgressServices _progressServices;
        private int _number;

        public LoadLevelState(GameStateMachine stateMachine,SceneLoader sceneLoader,IGameFactory gameFactory,IPersistenProgressServices progressServices) 
        {
            _gameStateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
            _progressServices = progressServices;
        }


        public void Enter(string payLoad, int payLoadInt)
        {
            _number = payLoadInt;
            _gameFactory.Cleanup();
            _sceneLoader.Load(payLoad, OnLoaded);
        }

        public void Exit()
        {
            
        }

        private void OnLoaded()
        {
            InitGameWorld();
            InformProgressReader();
            _gameStateMachine.Enter<GameLoopState>();
        }

        private void InformProgressReader()
        {
            foreach (ISavedProgressReader progessReader in _gameFactory.ProgressReaders)
                progessReader.LoadProgress(_progressServices.Progress);
        }

        private void InitGameWorld()
        {
            GameObject number = _gameFactory.CreateNumberLevel();
        }
    }
}