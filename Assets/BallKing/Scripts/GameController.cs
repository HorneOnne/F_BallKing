using System.Collections.Generic;
using System.Resources;
using UnityEngine;

namespace BallKing
{
    public class GameController : MonoBehaviour
    {
        public static GameController Instance { get; private set; }
        public static event System.Action OnNextLevel;


        [SerializeField] private Ball _ballPrefab;
        [Range(1, 6)]
        [SerializeField] private int _minBall;
        [Range(1, 6)]
        [SerializeField] private int _maxBall;


        [Header("RECT")]
        [SerializeField] private Transform _topLeft;
        [SerializeField] private Transform _topRight;
        [SerializeField] private Transform _bottomRight;
        [SerializeField] private Transform _bottomLeft;
        [SerializeField] private float _offset;

        [Header("Timer")]
        [SerializeField] private float _timerEachLevel = 10.0f;
        [SerializeField] private float _timeCounter = 0.0f;

        [Space(20)]
        [SerializeField] private int _currentBallQuantity;
        [SerializeField] private int _level;



        #region Properties
        public int Level { get => _level; }

        #endregion
        private void Awake()
        {
            Instance = this;
        }


        private void OnEnable()
        {
            Ball.OnBallDestroyed += OnLevelup;
        }

        private void OnDisable()
        {
            Ball.OnBallDestroyed -= OnLevelup;
        }

        private void Start()
        {
            _level = 0; 
            OnLevelup();
        }


        private void Update()
        {
            _timeCounter -= Time.deltaTime;
            if(_timeCounter < 0f)
            {
                Debug.Log("Game over");
            }
        }

        private bool CheckNetLevel()
        {
            if (_currentBallQuantity <= 0)
                return true;
            else
                return false;
        }

        private void GenerateBalls()
        {
            _currentBallQuantity = _level;
            _currentBallQuantity = Mathf.Clamp(_currentBallQuantity, _minBall, _maxBall);

            List<Vector2> listOfPoints = Utilities.GetRandomPointsInRectangle(_topLeft.position, _topRight.position, _bottomRight.position, _bottomLeft.position, _offset, 1.0f, _currentBallQuantity);

            for (int i = 0; i < _currentBallQuantity; i++)
            {
                Instantiate(_ballPrefab, listOfPoints[i], Quaternion.identity);
            }
        }


        private void OnLevelup()
        {
            _currentBallQuantity--;
            if (CheckNetLevel())
            {
                // Reset time
                _timeCounter = _timerEachLevel;


                _level++;
                GenerateBalls();

            }    
        }


    }
}
