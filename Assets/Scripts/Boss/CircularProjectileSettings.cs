using System;
using UnityEngine;

namespace Boss
{
    [Serializable]
    public struct CircularProjectileSettings
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private int _burstCount;
        [SerializeField] private int _itemPerBurst;
        [SerializeField] private float _delay;

        public GameObject Prefab => prefab;

        public int BurstCount => _burstCount;

        public float Delay => _delay;

        public int ItemPerBurst => _itemPerBurst;
    }
}