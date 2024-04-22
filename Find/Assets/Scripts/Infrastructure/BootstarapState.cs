using Scripts.Infrastructure.AssetManagement;
using Scripts.Services;
using Scripts.Services.SaveLoad;
using Scripts.StaticData;

namespace Scripts.Infrastructure
{
    public class BootstarapState : IState
    {
        public const string Initial = "Initial";

        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;

        public BootstarapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader,AllServices services)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _services = services;
            RegisterServices();
        }

        public void Enter()
        {
            _sceneLoader.Load(Initial, EnterLoadLevel);
        }

        public void Exit()
        {
            
        }

        private void EnterLoadLevel()
        {
            _gameStateMachine.Enter<LoadProgressState>();

        }

        private void RegisterServices()
        {
            RegisterStaticData();
            _services.RegisterSingle<IAssets>(new AssetProvider());
            _services.RegisterSingle<IPersistenProgressServices>(new PersistenProgressServices());
            _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IStaticDataService>(),_services.Single<IAssets>()));
            _services.RegisterSingle<ISaveLoadService>(new SaveLoadService(_services.Single<IPersistenProgressServices>(), _services.Single<IGameFactory>()));
        }

        private void RegisterStaticData()
        {
            IStaticDataService staticData = new StaticDataService();
            staticData.LoadLevel();
            _services.RegisterSingle(staticData);
        }
    }
}
