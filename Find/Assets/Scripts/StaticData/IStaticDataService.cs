using Scripts.Services;

namespace Scripts.StaticData
{
    public interface IStaticDataService : IService
    {
        LevelStaticData ForLevel(int level);
        void LoadLevel();
    }
}