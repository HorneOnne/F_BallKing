using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BallKing
{
    public class Player : MonoBehaviour
    {
        private Rigidbody2D _rb;
        private CircleCollider2D _circleCollider2D;
        [SerializeField] private float _moveSpeed;


        [Header("References")]
        [SerializeField] private ClickParticle _clickPs;
        [SerializeField] private ClickParticle _destroyBallPs;

        // Cached
        private Camera _mainCam;


        // Performance 
        [field: SerializeField] public int ParcitleCount { get; set; } = 0;
        private int _maxParticleInGame = 10;


        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _circleCollider2D = GetComponent<CircleCollider2D>();    
        }


        private void OnEnable()
        {
            ClickParticle.OnParticleDestroyed += () =>
            {
                ParcitleCount--;
            };
        }

        private void OnDisable()
        {
            ClickParticle.OnParticleDestroyed -= () =>
            {
                ParcitleCount--;
            };
        }

        private void Start()
        {
            Launch();
            _mainCam = Camera.main;
        }


        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                Vector2 mousePosition = _mainCam.ScreenToWorldPoint(Input.mousePosition);
                Vector2 direction = (mousePosition - _rb.position).normalized;
                _rb.velocity = direction * _moveSpeed;

                // Play Particle
                if(ParcitleCount < _maxParticleInGame)
                {
                    Instantiate(_clickPs, mousePosition, Quaternion.identity);
                    ParcitleCount++;
                }
                
            }
        }

        private void Launch()
        {
            float x = Random.Range(-1f, 1f);
            float y = Random.Range(-1f, 1f);
            _rb.velocity = new Vector2(x, y).normalized * _moveSpeed;
        }
 

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.GetComponent<Ball>() != null)
            {              
                var ps = Instantiate(_destroyBallPs, collision.transform.position, Quaternion.identity);
                Destroy(ps.gameObject, 1.0f);

                collision.GetComponent<Ball>().DestroyBall();
                GameManager.Instance.ScoreUp();

                SoundManager.Instance.PlaySound(SoundType.Hit, false);
            }
        }
    }
}
