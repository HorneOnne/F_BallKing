using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace BallKing
{
    public class UIGameover : CustomCanvas
    {
        [Header("Buttons")]             
        [SerializeField] private Button _replayBtn;
        [SerializeField] private Button _homeBtn;

        [Header("Texts")]
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _recordText;

        // Cached
        private GameManager _gameManager;

        private void OnEnable()
        {
            GameplayManager.OnGameOver += LoadScore;
            GameplayManager.OnGameOver += LoadBest;
        }

        private void OnDisable()
        {
            GameplayManager.OnGameOver -= LoadScore;
            GameplayManager.OnGameOver -= LoadBest;
        }


        private void Start()
        {
            _gameManager = GameManager.Instance;
            LoadScore();
            LoadBest();


            _replayBtn.onClick.AddListener(() =>
            {
                Loader.Load(Loader.Scene.GameplayScene);

                SoundManager.Instance.PlaySound(SoundType.Button, false);
            });

            _homeBtn.onClick.AddListener(() =>
            {
                Loader.Load(Loader.Scene.MenuScene);

                SoundManager.Instance.PlaySound(SoundType.Button, false);
            });
        }

        private void OnDestroy()
        {
            _replayBtn.onClick.RemoveAllListeners();
            _homeBtn.onClick.RemoveAllListeners();
        }

        private void LoadBest()
        {
            _scoreText.text = GameManager.Instance.Score.ToString();
        }

        private void LoadScore()
        {
            _recordText.text = GameManager.Instance.BestScore.ToString();
        }

    }
}
