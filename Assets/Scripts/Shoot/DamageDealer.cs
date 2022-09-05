using ObjectPool;
using UnityEngine;
using UnityEngine.Events;

namespace Shoot
{
    public class DamageDealer : MonoBehaviour
    {
        [SerializeField] private int _damage = 10;
        [SerializeField] private GameObject _hitEffect;
        [SerializeField] private bool _isDestroyOnTouch;
        [SerializeField] private UnityEvent _touched;
        
        private ParticleSystem _effect;
        
        public int Damage => _damage;

        public void Hit()
        {
            PlayHitEffect();
            
            if (_isDestroyOnTouch)
            {
                _touched?.Invoke();
            }
        }
        
        private void PlayHitEffect()
        {
            if (_hitEffect == null)
            {
                return;
            }
            
            var instance = Pool.Instance.GetGameObject(_hitEffect,
                                    transform.position,
                                    Quaternion.identity);

            _effect = instance.GetComponent<ParticleSystem>();
            Invoke(nameof(SetHitEffectToPool), _effect.main.duration + _effect.main.startLifetime.constantMax);
        }

        private void SetHitEffectToPool()
        {
            _effect.GetComponent<PoolItem>().Release();
        }
    }
}