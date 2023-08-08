using UnityEngine;

namespace BallKing
{
    public class ClickParticle : MonoBehaviour
    {
        public static event System.Action OnParticleDestroyed;
        private ParticleSystem _ps;

        private void Start()
        {
            _ps = GetComponent<ParticleSystem>();   
            Invoke(nameof(Destroy), 1.0f);
        }

        private void Destroy()
        {
            _ps.Stop(); // Stop emitting particles
            OnParticleDestroyed?.Invoke();
            Destroy(_ps.gameObject, _ps.main.duration); // Destroy after particle duration
        }
    }
}
