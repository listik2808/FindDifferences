using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Scripts
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private TMP_Text _textTimer;
        [SerializeField] private float _timeStart;
        private float _min;
        private float _sec;


        private void Start ()
        {
            _textTimer.text = _timeStart.ToString();
        }

        private void FixedUpdate()
        {
            if(_timeStart >= 0)
            {
                _timeStart -= Time.deltaTime;
                //_textTimer.text = Mathf.Round(_timeStart).ToString();
                _min = Mathf.FloorToInt(_timeStart / 60);
                _sec = Mathf.FloorToInt(_timeStart%60);
                _textTimer.text = string.Format("{0,00}:{1,00}", _min, _sec);
            }
            else
            {
                enabled = false;
            }
        }
    }
}