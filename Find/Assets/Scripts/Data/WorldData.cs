using System;

namespace Scripts.Data
{
    [Serializable]
    public class WorldData
    {
        public string Main = "Main";
        public int CountLevel;

        public WorldData(string nameLevelScene,int numberLevel) 
        {
            Main = nameLevelScene;
            CountLevel = numberLevel;
        }
    }
}