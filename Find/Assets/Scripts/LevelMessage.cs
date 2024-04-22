using Scripts.Data;
using Scripts.Services;
using TMPro;
using UnityEngine;

namespace Scripts
{
    public class LevelMessage : MonoBehaviour
    {
        [SerializeField] private TMP_Text _levelText;
        private int _level = 1;
        private IPersistenProgressServices _progressServices;

        private void Start ()
        {
            _progressServices = AllServices.Continer.Single<IPersistenProgressServices>();
            if (_progressServices.Progress.WorldData.CountLevel != 0)
            {
                _level = _progressServices.Progress.WorldData.CountLevel;
            }
            _levelText.text = "Level : " + _level.ToString();
        }

        public void Up() =>
            AddLevel();

        private void AddLevel()
        {
            _level++;
            _progressServices.Progress.WorldData.CountLevel = _level;
        }
    }
}