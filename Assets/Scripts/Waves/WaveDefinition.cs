using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Waves
{
    [Serializable]
    public struct WaveDefinition
    {
        [SerializeField] private bool _isBossWave;
        [SerializeField] private PathDefinition[] _path;
        [SerializeField] private GameObject[] _enemyPrefabs;
        [SerializeField] private float _moveSpeed;
        
        [SerializeField] private float _timeBetweenEnemySpawns;
        [SerializeField] private float _spawnTimeVariance;
        [SerializeField] private float _minimumSpawnTime;
        [SerializeField] private float _breaksAfterWave;

        private Transform _currentPath;
        
        public bool IsBossWave => _isBossWave;
        public PathDefinition[] Path => _path;
        public int PathCount => _path.Length;
        public float MoveSpeed => _moveSpeed;
        public int BreaksAfterWave => Mathf.CeilToInt(_breaksAfterWave * 1000);
        
        public Transform GetStartingWayPoint(int index)
        {
            _currentPath = _path[index].Path.GetComponent<Transform>();
            return _path[index].Path.GetComponent<Transform>().GetChild(0);
        }

        public GameObject GetEnemyPrefab()
        {
            int random = Random.Range(0, _enemyPrefabs.Length);
            return _enemyPrefabs[random];
        }
        
        public GameObject GetBossPrefab()
        {
            return _enemyPrefabs[0];
        }
        
        public float GetRandomSpawnTime()
        {
            float spawnTime = Random.Range(_timeBetweenEnemySpawns - _spawnTimeVariance,
                _timeBetweenEnemySpawns + _minimumSpawnTime);

            return Mathf.Clamp(spawnTime, _minimumSpawnTime, float.MaxValue);
        }
        
        public List<Transform> GetWaypoints()
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