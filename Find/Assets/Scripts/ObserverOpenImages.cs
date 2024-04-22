using Scripts.ButtonClicking;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts
{
    public class ObserverOpenImages : MonoBehaviour
    {
        [SerializeField] private List<ClicButtonUi> _buttonUiList;
        [SerializeField] private Image _screenVictory;
        [SerializeField] private Image _screenLost;
        [SerializeField] private Timer _timer;
        [SerializeField] private Button _buttonRestart;
        [SerializeField] private Button _buttonResetVictory;
        [SerializeField] private LevelMessage _levelMessage;
        private int _countOpenImage = 0;
        private int _maxOpenImage = 0;

        private void OnEnable()
        {
            _timer.EndTime += ScreenLostOpen;
            _buttonRestart.onClick.AddListener(Uplevel);
            _buttonResetVictory.onClick.AddListener(Uplevel);
            foreach (ClicButtonUi button in _buttonUiList)
            {
                button.Selected += Counter;
            }
        }

        private void OnDisable()
        {
            _timer.EndTime -= ScreenLostOpen;
            _buttonRestart.onClick.RemoveListener(Uplevel);
            _buttonResetVictory.onClick.RemoveListener(Uplevel);
            foreach (ClicButtonUi button in _buttonUiList)
            {
                button.Selected -= Counter;
            }
        }

        private void Start()
        {
            _maxOpenImage = _buttonUiList.Count;
        }

        private void Counter()
        {
            _countOpenImage++;
            if(_countOpenImage == _maxOpenImage)
            {
                _timer.enabled = false;
                _screenVictory.gameObject.SetActive(true);
            }
        }

        private void ScreenLostOpen()
        {
            _timer.enabled = false;
            _screenLost.gameObject.SetActive(true);
        }

        private void Uplevel()
        {
            _levelMessage.Up();
        }
    }
}