using UnityEngine;

namespace Boss
{
    public class DirectionalProjectile : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Rigidbody2D _rigidbody;
        
        public void Launch(Vector2 direction)
        {
            _rigidbody.AddForce(direction * _speed, ForceMode2D.Impulse);
        }
    }
}