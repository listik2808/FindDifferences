using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Data
{
    [Serializable]
    public class PlayerProgress 
    {
        public WorldData WorldData;

        public PlayerProgress(string InitialLevelName,int numerLevel)
        {
            WorldData = new WorldData(InitialLevelName, numerLevel);
        }
    }
}