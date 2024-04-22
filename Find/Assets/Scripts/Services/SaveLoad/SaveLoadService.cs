using Scripts.Data;
using Scripts.Infrastructure;
using UnityEngine;

namespace Scripts.Services.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private readonly IPersistenProgressServices _progressService;
        private readonly IGameFactory _gameFactory;
        private string _json;

        public SaveLoadService(IPersistenProgressServices progressService, IGameFactory gameFactory)
        {
            _progressService = progressService;
            _gameFactory = gameFactory;
            SaveOrLoad.Init();
        }

        public void SaveProgress()
        {
            foreach (ISavedProgress progressWriter in _gameFactory.ProgressWriters)
                progressWriter.UpdateProgress(_progressService.Progress);

            _json = JsonUtility.ToJson(_progressService.Progress);
             SaveOrLoad.Save(_json);
        }

        public PlayerProgress LoadProgress()
        {
            _json = SaveOrLoad.Load();

            if (_json != null)
            {
                _progressService.Progress = JsonUtility.FromJson<PlayerProgress>(_json);
                return _progressService.Progress;
            }
            return _progressService.Progress;
        }
    }
}
