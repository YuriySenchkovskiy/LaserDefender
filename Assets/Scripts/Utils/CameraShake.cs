using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Utils
{
    public class CameraShake : MonoBehaviour
    {
        [SerializeField] private float _shakeDuration = 0.5f;
        [SerializeField] private float _shakeMagnitude = 0.5f;

        private Vector3 _initialPosition;
        
        private void Start()
        {
            _initialPosition = transform.position;
        }

        public void Damaged()
        {
            StartCoroutine(Shake());
        }

        private IEnumerator Shake()
        {
            float elapsedTime = 0;

            while (elapsedTime < _shakeDuration)
            {
                transform.position = _initialPosition + (Vector3)Random.insideUnitCircle * _shakeMagnitude;
                elapsedTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }

            transform.position = _initialPosition;
        }
    }
}