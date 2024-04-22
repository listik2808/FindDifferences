using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<int, LevelStaticData> _level;

        public void LoadLevel()
        {
            _level = Resources.LoadAll<LevelStaticData>("StaticDataLevel")
                .ToDictionary(x => x.NumberLeve, x => x);
        }

        public LevelStaticData ForLevel(int level) =>
            _level.TryGetValue(level, out LevelStaticData levelStaticData) ? levelStaticData : null;
    }
}
