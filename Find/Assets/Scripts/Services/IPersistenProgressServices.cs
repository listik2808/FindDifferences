using Scripts.Data;
using Scripts.Services;

namespace Scripts.Services
{
    public interface IPersistenProgressServices : IService
    {
        PlayerProgress Progress { get; set; }
    }

}