using UnityEngine;
using DG.Tweening;

namespace BallKing
{
    public class ScaleUp : MonoBehaviour
    {
        public Vector3 targetScale = new Vector3(2f, 2f, 1f);
        public float scaleDuration = 1f;

        private void Start()
        {
            // Start scaling up when the script starts
            ScaleObjectUp();
        }

        private void ScaleObjectUp()
        {
            // Use DOScale method to scale to the targetScale over scaleDuration
            transform.DOScale(targetScale, scaleDuration)
                .SetEase(Ease.OutQuad)
                .OnComplete(ScalingComplete);
        }

        private void ScalingComplete()
        {
            // Scaling animation complete, add any further actions here
            Debug.Log("Scaling animation complete");
        }
    }
}
