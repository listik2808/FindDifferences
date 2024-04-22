using System;
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

        public float TimerTim => _timeStart;

        public event Action EndTime;

        private void Start ()
        {
            _textTimer.text = _timeStart.ToString();
        }

        private void FixedUpdate()
        {
            _timeStart -= Time.deltaTime;
            if (_timeStart > 0)
            {
                ShowTime();
            }
            else
            {
                EndTime?.Invoke();
            }
        }

        private void ShowTime()
        {
            _min = Mathf.FloorToInt(_timeStart / 60);
            _sec = Mathf.FloorToInt(_timeStart % 60);
            _textTimer.text = string.Format("{0,00}:{1,00}", _min, _sec);
        }
    }
}