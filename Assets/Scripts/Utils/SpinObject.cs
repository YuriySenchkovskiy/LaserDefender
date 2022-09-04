using UnityEngine;

namespace Utils
{
    public class SpinObject : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private void Update()
        {
            transform.RotateAround(transform.position, Vector3.forward, _speed);
        }
    }
}