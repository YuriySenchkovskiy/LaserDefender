using System.Collections;
using ObjectPool;
using UnityEngine;
using Utils;

namespace Waves
{
    public class WaveSpawner : MonoBehaviour
    {
        [SerializeField] private float _timeBetweenWaves = 0.2f;
        [SerializeField] private float _zRotation = 180f;

        private WaveDefinition _currentWave;
        private WaveStatus _waveStatus = WaveStatus.InProgress;
        private WaitForSeconds _waitBetweenSpawn;
        private WaitForSeconds _waitBetweenWaves;

        public WaveStatus WaveStatus => _waveStatus;
        public WaveDefinition CurrentWave => _currentWave;

        private void Awake()
        {
            _waitBetweenWaves = new WaitForSeconds(_timeBetweenWaves);
        }

        public void SetWave(WaveDefinition waveDefinition)
        {
            if (!enabled)
                return;
            
            _waveStatus = WaveStatus.InProgress;
            _currentWave = waveDefinition;
            SpawnWaves();
        }

        public void SetWaveStatusIsEnd()
        {
            _waveStatus = WaveStatus.End;
        }

        private void SpawnWaves()
        {
            switch (_currentWave.IsBossWave)
            {
                case true:
                    SpawnBoss();
                    break;
                case false:
                    StartCoroutine(SpawnEnemy());
                    break;
            }
        }

        private void SpawnBoss()
        {
            SpawnUtils.Spawn(_currentWave.GetBossPrefab(),
                _currentWave.GetStartingWayPoint(_currentWave.PathCount - 1).position,
                Quaternion.Euler(0, 0, _zRotation));
        }

        private IEnumerator SpawnEnemy()
        {
            for (var i = 0; i < _currentWave.PathCount; i++)
            {
                _waitBetweenSpawn = new WaitForSeconds(_currentWave.GetRandomSpawnTime());

                for (var j = 0; j < _currentWave.Path[i].EnemyNumber; j++)
                {
                    Pool.Instance.GetGameObject(_currentWave.GetEnemyPrefab(),
                        _currentWave.GetStartingWayPoint(i).position,
                        Quaternion.Euler(0, 0, _zRotation));
                    yield return _waitBetweenSpawn;
                }

                yield return _waitBetweenWaves;
            }
            
            _waveStatus = WaveStatus.End;
        }
    }
}