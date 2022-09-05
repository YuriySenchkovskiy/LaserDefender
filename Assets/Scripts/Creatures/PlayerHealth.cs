using UnityEngine;

namespace Creatures
{
    public class PlayerHealth : Health
    {
        [SerializeField] private float _newHealthCoefficient;
        
        [Header("Events")]
        [SerializeField] private Observer.IntEvent _startValueReady;
        [SerializeField] private Observer.IntEvent _playerHealthChanged;
        [SerializeField] private Observer.Event _playerDestroyed;

        private void Start()
        {
            _startValueReady.Occured(HealthValue);
        }
        
        public void RestoreHealth()
        {
            var newTotalHealth = StartHealth * _newHealthCoefficient;
            StartHealth = Mathf.CeilToInt(newTotalHealth);
            HealthValue = StartHealth;
            _startValueReady.Occured(HealthValue);
        }

        protected override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            _playerHealthChanged.Occured(HealthValue);
        }

        protected override void Die()
        {
            _playerDestroyed.Occured();
            Destroy(gameObject);
        }
    }
}