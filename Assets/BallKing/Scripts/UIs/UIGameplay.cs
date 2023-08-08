using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace BallKing
{
    public class UIGameplay : CustomCanvas
    {
        [Header("References")]
        [SerializeField] private Slider _timeSlider; 
        [SerializeField] private TextMeshProUGUI _scoreText;

        // cached
        private GameController _gameController;
        private float _updateFrequency = 0.1f;
        private float _updateTimer = 0.0f;


        private void OnEnable()
        {
            GameManager.OnScoreUp += UpdateScoreUI;
        }

        private void OnDisable()
        {
            GameManager.OnScoreUp -= UpdateScoreUI;
        }
        private void Start()
        {
            _gameController = GameController.Instance;
            UpdateScoreUI();
        }

        private void Update()
        {
            if(Time.time - _updateTimer > _updateFrequency)
            {
                _updateTimer = Time.time;
                UpdateSlider();
            }    
        }

        private void UpdateSlider()
        {
            // Map yourFloatValue from the range [minValue, maxValue] to the range [0, 1]
            float mappedValue = Mathf.InverseLerp(0, _gameController.TimeEachLevel, _gameController.TimeCounter);

            // Set the slider value to the mapped value
            _timeSlider.value = mappedValue;
        }

        private void UpdateScoreUI()
        {
            _scoreText.text = GameManager.Instance.Score.ToString();
        }
    }
}
