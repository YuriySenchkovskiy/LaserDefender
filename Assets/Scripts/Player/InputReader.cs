using Shoot;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class InputReader : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private Shooter[] _shooters;
        
        private void OnMove(InputValue value)
        {
            var input = value.Get<Vector2>();
            _playerMovement.SetDirection(input);
        }
        
        private void OnFire(InputValue value)
        {
            foreach (var shooter in _shooters)
            {
                shooter.Shoot(value.isPressed);
            }
        }
    }
}