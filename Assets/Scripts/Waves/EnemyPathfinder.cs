using System.Collections.Generic;
using ObjectPool;
using UnityEngine;

namespace Waves
{
    public class EnemyPathfinder : MonoBehaviour
    {
        [SerializeField] private PoolItem _poolItem;
        
        private WaveSpawner _spawner;
        private WaveDefinition _waveDefinition;
        private List<Transform> _wayPoints;
        private int _wayPointIndex = 0;
        private int _zeroPosition = 0;

        private void Awake()
        {
            _spawner = FindObjectOfType<WaveSpawner>();
        }

        private void Start()
        {
            _waveDefinition = _spawner.CurrentWave;
            _wayPoints = _waveDefinition.GetWaypoints();
            transform.position = _wayPoints[_wayPointIndex].position;
        }

        private void Update()
        {
            FollowPath();
        }

        public void SetStartValue()
        {
            _spawner = FindObjectOfType<WaveSpawner>();
            _waveDefinition = _spawner.CurrentWave;
            _wayPointIndex = 0;
            _wayPoints = _waveDefinition.GetWaypoints();
            transform.position = _wayPoints[_wayPointIndex].position;
        }

        private void FollowPath()
        {
            if (_wayPointIndex < _wayPoints.Count)
            {
                MoveToTarget();
            }
            else if(!_waveDefinition.IsBossWave && _wayPointIndex == _wayPoints.Count)
            {
                _poolItem.Release();
            }
            else if (_waveDefinition.IsBossWave && _wayPointIndex == _wayPoints.Count && enabled)
            {
                _wayPointIndex = _zeroPosition;
                MoveToTarget();
            }
        }

        private void MoveToTarget()
        {
            Vector3 targetPosition = _wayPoints[_wayPointIndex].position;
            float delta = _waveDefinition.MoveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, 
                                targetPosition, 
                                delta);
        
            if (transform.position == targetPosition)
            {
                _wayPointIndex++;
            }
        }
    }
}