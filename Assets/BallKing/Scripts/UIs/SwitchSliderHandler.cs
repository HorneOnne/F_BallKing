using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.UI;
using TMPro;

namespace BallKing
{
    public class SwitchSliderHandler : MonoBehaviour
    {
        public event Action<bool> OnToggleClicked;

        [SerializeField] private Button _switchBtn;
        [SerializeField] private Image _backgroundImage;

        [Header("Sprites")]
        [SerializeField] private Sprite _onImageBackground;
        [SerializeField] private Sprite _offImageBackground;

        [Header("Texts")]
        [SerializeField] private TextMeshProUGUI _onText;
        [SerializeField] private TextMeshProUGUI _offText;

        public bool ToggleOn = true;


        // Cached
        private float _offsetToggleX;

        private void Awake()
        {
            _offsetToggleX = _switchBtn.transform.localPosition.x;
        }
        private void OnEnable()
        {
            _switchBtn.onClick.AddListener(OnSwitchButtonClicked);
        }

        private void OnDisable()
        {
            _switchBtn.onClick.RemoveAllListeners();
        }

        private void Start()
        {           
            UpdateUI();
        }

        public void OnSwitchButtonClicked()
        {
            ToggleOn = !ToggleOn;

            UpdateUI();
            OnToggleClicked?.Invoke(ToggleOn);
        }

        public void UpdateUI()
        {
            if (ToggleOn)
            {
                _switchBtn.transform.DOLocalMoveX(_offsetToggleX, 0.2f);
                _onText.gameObject.SetActive(true);
                _offText.gameObject.SetActive(false);

                _backgroundImage.sprite = _onImageBackground;
            }
            else
            {
                _switchBtn.transform.DOLocalMoveX(-_offsetToggleX, 0.2f);
                _onText.gameObject.SetActive(false);
                _offText.gameObject.SetActive(true);

                _backgroundImage.sprite = _offImageBackground;
            }
        }
    }
}
