using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace BallKing
{
    public class UIGameover : CustomCanvas
    {
        [Header("Buttons")]       
        [SerializeField] private Button _menuBtn;
        [SerializeField] private Button _replayBtn;

        [Header("Texts")]
        [SerializeField] private TextMeshProUGUI _gameoverText;
        [SerializeField] private TextMeshProUGUI _replayBtnText;
        [SerializeField] private TextMeshProUGUI _menuBtnText;
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

            _menuBtn.onClick.AddListener(() =>
            {
                Loader.Load(Loader.Scene.MenuScene);

                SoundManager.Instance.PlaySound(SoundType.Button, false);
            });
        }

        private void OnDestroy()
        {
            _replayBtn.onClick.RemoveAllListeners();
            _menuBtn.onClick.RemoveAllListeners();
        }

        private void LoadBest()
        {
            
        }

        private void LoadScore()
        {

        }

    }
}
