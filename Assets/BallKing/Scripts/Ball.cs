using UnityEngine;

namespace BallKing
{
    public class Ball : MonoBehaviour
    {
        public static event System.Action OnBallDestroyed;

        public void DestroyBall()
        {
            OnBallDestroyed?.Invoke();
            Destroy(this.gameObject);
        }

    }
}
