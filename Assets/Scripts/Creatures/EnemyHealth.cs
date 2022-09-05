using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace Creatures
{
    public class EnemyHealth : Health
    {
        [SerializeField] private bool _isBoss;
        [SerializeField] private UnityEvent _enemyDie;
        
        [Header("Events")]
        [SerializeField] private Observer.IntEvent _enemyDestroyed;
        [SerializeField] private Observer.Event _enemyDamaged;
        [SerializeField] private Observer.Event _bossDestroyed;

        public void SetStartHealth()
        {
            HealthValue = StartHealth;
        }
        
        protected override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            _enemyDamaged.Occured();
        }

        protected override void Die()
        {
            if (_isBoss)
            {
                _bossDestroyed.Occured();
                Destroy(gameObject);
            }
            
            _enemyDestroyed.Occured(StartHealth);
            _enemyDie?.Invoke();
        }
    }
}