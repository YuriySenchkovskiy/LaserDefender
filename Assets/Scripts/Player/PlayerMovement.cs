using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private float _paddingLeft;
        [SerializeField] private float _paddingRight;
        [SerializeField] private float _paddingTop;
        [SerializeField] private float _paddingButtom;

        private Vector2 _direction;
        private Vector2 _minBounds;
        private Vector2 _maxBounds;

        private void Start()
        {
            InitBounds();
        }

        private void Update()
        {
            Move();
        }

        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }

        public void SetSpeed(int value)
        {
            _moveSpeed = value;
        }

        private void Move()
        {
            Vector3 delta = _direction * _moveSpeed * Time.deltaTime;
            Vector2 newPosition = new Vector2();
            newPosition.x = Mathf.Clamp(transform.position.x + delta.x, _minBounds.x + _paddingLeft, _maxBounds.x - _paddingRight);
            newPosition.y = Mathf.Clamp(transform.position.y + delta.y, _minBounds.y + _paddingButtom, _maxBounds.y - _paddingTop);
            transform.position = newPosition;
        }

        private void InitBounds()
        {
            Camera mainCamera = Camera.main;
            _minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
            _maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
        }
    }
}