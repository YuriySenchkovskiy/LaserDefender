using System;
using UnityEngine;

namespace Waves 
{
    [Serializable]
    public struct PathDefinition
    {
        [SerializeField] private GameObject _path;
        [SerializeField] private int _enemyNumber;

        public GameObject Path => _path;
        public int EnemyNumber => _enemyNumber;
    }
}