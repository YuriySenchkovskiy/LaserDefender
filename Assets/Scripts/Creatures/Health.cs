using Shoot;
using UnityEngine;
using UnityEngine.Events;

namespace Creatures
{
    public class Health : MonoBehaviour
    {
        [Header("General")]
        [SerializeField] private bool _isPlayer;
        [SerializeField] private bool _isBoss;
        [SerializeField] private int _health = 50;
        [SerializeField] private UnityEvent _enemyDie;
        [SerializeField] private float _newHealthCoefficient;
        
        [Header("Events")]
        [SerializeField] private Observer.IntEvent _startValueReady;
        [SerializeField] private Observer.IntEvent _enemyDestroyed;
        [SerializeField] private Observer.Event _playerDestroyed;
        [SerializeField] private Observer.Event _enemyDamaged;
        [SerializeField] private Observer.IntEvent _playerHealthChanged;
        [SerializeField] private Observer.Event _bossDestroyed;
        
        private int _startHealth;

        private void Awake()
        {
            _startHealth = _health;
        }

        private void Start()
        {
            if (_isPlayer)
            {
                _startValueReady.Occured(_health);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            DamageDealer damageDealer = other.GetComponent<DamageDealer>();

            if (damageDealer != null)
            {
                TakeDamage(damageDealer.GetDamage());
                damageDealer.Hit();
            }
        }

        public void SetStartHealth()
        {
            _health = _startHealth;
        }

        public void RestoreHealth()
        {
            var newTotalHealth = _startHealth * _newHealthCoefficient;
            _startHealth = Mathf.CeilToInt(newTotalHealth);
            _health = _startHealth;
            _startValueReady.Occured(_health);
        }

        private void TakeDamage(int damage)
        {
            _health -= damage;

            if (_isPlayer)
            {
                _playerHealthChanged.Occured(_health);
            }
            else
            {
                _enemyDamaged.Occured();
            }

            if (_health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            if (!_isPlayer && !_isBoss)
            {
                _enemyDestroyed.Occured(_startHealth);
                _enemyDie?.Invoke();
            }
            else if (_isBoss)
            {
                _enemyDestroyed.Occured(_startHealth);
                _bossDestroyed.Occured();
                _enemyDie?.Invoke();
                Destroy(gameObject);
            }
            else if (_isPlayer)
            {
                _playerDestroyed.Occured();
                Destroy(gameObject);
            }
        }
    }
}