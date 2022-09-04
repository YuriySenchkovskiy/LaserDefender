using System.Collections;
using ObjectPool;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Shoot
{
    public class Shooter : MonoBehaviour
    {
        [Header("General")]
        [SerializeField] private GameObject _projectilePrefab;
        [SerializeField] private float _projectileSpeed = 10f;
        [SerializeField] private float _baseWaitTime = 0.2f;
        
        [SerializeField] private Observer.Event _shooted;
        [SerializeField] private float _zRotation;
        
        [Header("AI")]
        [SerializeField] private bool _useAI;
        [SerializeField] private float _firingRateVariance = 0f;
        [SerializeField] private float _minimumFiringRateVariance = 0.1f;

        private bool _isFiring;
        private Coroutine _firingCoroutine;

        private void Start()
        {
            SetStartShooterSetting();
        }

        private void Update()
        {
            Fire();
        }

        public void SetStartShooterSetting()
        {
            if (!_useAI)
            {
                return;
            }
            
            _isFiring = true;
            
            if (_firingCoroutine == null)
            {
                return;
            }
            
            StopCoroutine(_firingCoroutine);
            _firingCoroutine = null;
        }
        
        public void Shoot(bool status)
        {
            _isFiring = status;
        }

        private void Fire()
        {
            if (_isFiring && _firingCoroutine == null)
            {
                _firingCoroutine = StartCoroutine(FireContinuously());
            }
            else if (!_isFiring && _firingCoroutine != null)
            {
                StopCoroutine(_firingCoroutine);
                _firingCoroutine = null;
            }
        }

        private IEnumerator FireContinuously()
        {
            while (_isFiring)
            { 
                var instance = Pool.Instance.GetGameObject(_projectilePrefab,
                                        transform.position,
                                        Quaternion.Euler(0, 0, _zRotation));
                
                Rigidbody2D rigidbody2D = instance.GetComponent<Rigidbody2D>();
                
                if (rigidbody2D != null)
                {
                    rigidbody2D.velocity = transform.up * _projectileSpeed;
                }
                
                float timeToNextProjectile = Random.Range(_baseWaitTime - _firingRateVariance,
                    _baseWaitTime + _firingRateVariance);
                timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, 
                    _minimumFiringRateVariance, 
                    float.MaxValue);
                _shooted.Occured();
                yield return new WaitForSeconds(timeToNextProjectile) ;
            }
        }
    }
}