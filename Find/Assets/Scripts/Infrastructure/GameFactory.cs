using Scripts.Infrastructure.AssetManagement;
using Scripts.Services;
using Scripts.StaticData;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Assertions;

namespace Scripts.Infrastructure
{
    public class GameFactory : IGameFactory
    {
        public const string Spawner = "SpawnerPrefab/Spawner";
        private readonly IStaticDataService _staticData;
        private readonly IAssets _assets;
        public List<ISavedProgressReader> ProgressReaders { get; } = new List<ISavedProgressReader>();
        public List<ISavedProgress> ProgressWriters { get; } = new List<ISavedProgress>();


        public GameFactory(IStaticDataService staticData ,IAssets assets)
        {
            _staticData = staticData;
            _assets = assets;
        }

        public void Cleanup()
        {
            ProgressReaders.Clear();
            ProgressWriters.Clear();
        }

        public GameObject CreateNumberLevel()
        {
            GameObject gameObject = InstantiateRegistered(Spawner);
            return gameObject;
        }

        public GameObject CreateLevel(int level)
        {
            LevelStaticData levelStaticData = _staticData.ForLevel(level);
            GameObject levelNumber = Object.Instantiate(levelStaticData.Prefab);
            RegisterProgressWatchers(levelNumber);
            return levelNumber;
        }

        public void Register(ISavedProgressReader progessReader)
        {
            if (progessReader is ISavedProgress progressWrite)
                ProgressWriters.Add(progressWrite);

            ProgressReaders.Add(progessReader);
        }

        private void RegisterProgressWatchers(GameObject gameObject)
        {
            foreach (ISavedProgressReader progessReader in gameObject.GetComponentsInChildren<ISavedProgressReader>())
                Register(progessReader);
        }

        private GameObject InstantiateRegistered(string prefabPath)
        {
            GameObject gameObject = _assets.Instantiate(path: prefabPath);
            RegisterProgressWatchers(gameObject);

            return gameObject;
        }

    }
}
