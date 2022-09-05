using Shoot;
using UnityEngine;

namespace Creatures
{
    public abstract class Health : MonoBehaviour
    {
        [Header("General")]
        [SerializeField] protected int HealthValue = 50;
        
        protected int StartHealth;

        private void Awake()
        {
            StartHealth = HealthValue;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            DamageDealer damageDealer = other.GetComponent<DamageDealer>();

            if (damageDealer != null)
            {
                TakeDamage(damageDealer.Damage);
                damageDealer.Hit();
            }
        }

        protected virtual void TakeDamage(int damage)
        {
            HealthValue -= damage;
            
            if (HealthValue <= 0)
            {
                Die();
            }
        }

        protected abstract void Die();
    }
}