using Scripts.Services;
using Scripts.StaticData;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Infrastructure
{
    public interface IGameFactory : IService
    {
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressWriters { get; }

        void Cleanup();
        GameObject CreateLevel(int level);
        GameObject CreateNumberLevel();
    }
}