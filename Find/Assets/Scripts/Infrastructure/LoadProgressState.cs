using Scripts.Data;
using Scripts.Services;
using Scripts.Services.SaveLoad;
using System;

namespace Scripts.Infrastructure
{
    public class LoadProgressState : IState
    {
        private const string MainScene = "Main";
        private const int NumberScene = 1;

        private readonly GameStateMachine _gameStateMachine;
        private readonly IPersistenProgressServices _progress;
        private ISaveLoadService _saveLoadService;

        public LoadProgressState(GameStateMachine gameStateMachine,IPersistenProgressServices progressServices,ISaveLoadService saveLoadService) 
        {
            _gameStateMachine = gameStateMachine;
            _progress = progressServices;
            _saveLoadService = saveLoadService;
        }

        public void Enter()
        {
            LoadProgressOrInitNew();
            _gameStateMachine.Enter<LoadLevelState, string,int>(_progress.Progress.WorldData.Main,_progress.Progress.WorldData.CountLevel);
        }


        public void Exit()
        {
        }

        private void LoadProgressOrInitNew()
        {
            _progress.Progress = _saveLoadService.LoadProgress() ?? NewProgress();
        }

        private PlayerProgress NewProgress() =>
            new PlayerProgress(MainScene, NumberScene);
    }
}