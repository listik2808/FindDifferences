using Scripts.Data;
using Scripts.Infrastructure;
using Scripts.Services;
using Scripts.StaticData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Scripts.Logic
{
    public class Spawn : MonoBehaviour,ISavedProgress
    {
        private int Level =1;
        private IGameFactory _factory;

        private void Awake()
        {
            _factory = AllServices.Continer.Single<IGameFactory>();
        }

        public void LoadProgress(PlayerProgress progress)
        {
            Spawne();
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            Level = progress.WorldData.CountLevel;
        }

        private void Spawne()
        {
            GameObject numberLevel = _factory.CreateLevel(Level);
        }
    }
}
