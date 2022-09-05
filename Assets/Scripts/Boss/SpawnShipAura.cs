using UnityEngine;
using Utils;

namespace Boss
{
    public class SpawnShipAura : MonoBehaviour
    {
        [SerializeField] private GameObject _aura;
        [SerializeField] private float _zRotation = 180f;

        private void Awake()
        {
            SpawnUtils.Spawn(_aura, 
                            transform.position, 
                            Quaternion.Euler(0, 0, _zRotation),
                            gameObject);
        }
    }
}