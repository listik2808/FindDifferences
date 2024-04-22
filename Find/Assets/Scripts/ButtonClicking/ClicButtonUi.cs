using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.ButtonClicking
{
    public class ClicButtonUi : MonoBehaviour
    {
        [SerializeField] private Button _buttonScreenOne;
        [SerializeField] private Button _buttonScreenTwo;
        [SerializeField] private ParticleSystem _particleSystem;
        private bool _isOpen = false;

        public event Action Selected;

        private void OnEnable()
        {
            _buttonScreenOne.onClick.AddListener(StartPaticle);
            _buttonScreenTwo.onClick.AddListener(StartPaticle);
        }

        private void OnDisable()
        {
            _buttonScreenOne.onClick.RemoveListener(StartPaticle);
            _buttonScreenTwo.onClick.RemoveListener(StartPaticle);
        }

        private void StartPaticle()
        {
            if(_isOpen == false )
            {
                _particleSystem.gameObject.SetActive(true);
                _particleSystem.Play();
                _isOpen = true;
                Selected?.Invoke();
            }
        }
    }
}