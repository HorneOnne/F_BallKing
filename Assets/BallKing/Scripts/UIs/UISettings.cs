using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace BallKing
{
    public class UISettings : CustomCanvas
    {
        [Header("Buttons")]
        [SerializeField] private Button _backBtn;

        [Header("Sliders")]
        [SerializeField] private SwitchSliderHandler _soundSlider;
        [SerializeField] private SwitchSliderHandler _musicSlider;


        private void OnEnable()
        {
            _soundSlider.OnToggleClicked += OnToggleSound;
            _musicSlider.OnToggleClicked += OnToggleMusic;
        }

       

        private void OnDisable()
        {
            _soundSlider.OnToggleClicked -= OnToggleSound;
            _musicSlider.OnToggleClicked -= OnToggleMusic;
        }


        private void Start()
        {
            Debug.Log(SoundManager.Instance.isMusicActive);
            _soundSlider.ToggleOn = SoundManager.Instance.isSoundFXActive;
            _musicSlider.ToggleOn = SoundManager.Instance.isMusicActive;
            _soundSlider.UpdateUI();
            _musicSlider.UpdateUI();


            _backBtn.onClick.AddListener(() =>
            {
                UIManager.Instance.DisplaySettingsMenu(false);

                SoundManager.Instance.PlaySound(SoundType.Button, false);
            });   
        }

        private void OnDestroy()
        {
            _backBtn.onClick.RemoveAllListeners();
        }


        private void OnToggleSound(bool isToggleOn)
        {
            SoundManager.Instance.isSoundFXActive = isToggleOn;
            SoundManager.Instance.MuteSoundFX(!SoundManager.Instance.isSoundFXActive);
        }


        private void OnToggleMusic(bool isToggleOn)
        {
            SoundManager.Instance.isMusicActive = isToggleOn;
            SoundManager.Instance.MuteBackground(!SoundManager.Instance.isMusicActive);
        }


    }
}
