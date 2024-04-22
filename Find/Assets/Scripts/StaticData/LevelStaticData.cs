using UnityEngine;

namespace Scripts.StaticData
{
    [CreateAssetMenu(fileName ="LevelData",menuName =("StaticData/Level"))]
    public class LevelStaticData : ScriptableObject
    {
        public int NumberLeve;
        public GameObject Prefab;
    }
}
