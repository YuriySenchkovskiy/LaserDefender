using System.Collections.Generic;
using UnityEngine;

namespace Waves
{
    public class AsteroidPathfinder : MonoBehaviour
    {
        [SerializeField] private Transform _currentPath;
        [SerializeField] private float _speed;

        private List<Transform> _path;
        private int _wayPointIndex = 0;
        private int _zeroPosition = 0;

        private void Start()
        {
            _path = GetWaypoints();
            transform.position = _path[_wayPointIndex].position;
        }
        
        private void Update()
        {
            if (_wayPointIndex < _path.Count)
            {
                MoveToTarget();
            }
            else if (_wayPointIndex == _path.Count && enabled)
            {
                _wayPointIndex = _zeroPosition;
                MoveToTarget();
            }
                
        }

        private void MoveToTarget()
        {
            Vector3 targetPosition = _path[_wayPointIndex].position;
            float delta = _speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, 
                targetPosition, 
                delta);
        
            if (transform.position == targetPosition)
            {
                _wayPointIndex++;
            }
        }
        
        private List<Transform> GetWaypoints()
        {
            List<Transform> wayPoints = new List<Transform>();

            foreach (Transform child in _currentPath)
            {
                wayPoints.Add(child);
            }

            return wayPoints;
        }
    }
}