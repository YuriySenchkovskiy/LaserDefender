using UnityEngine;

namespace Utils
{
    public class SpawnComponent : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private float _zRotation = 180f;
        [SerializeField] private float _lifeTime;
        [SerializeField] private bool _isOnAwake;

        private void Awake()
        {
            if (_isOnAwake)
            {
                Spawn();
            }
        }

        public void Spawn()
        {
            var instance = SpawnUtils.Spawn(_prefab, 
                                    transform.position, 
                                    Quaternion.Euler(0, 0, _zRotation));
            
            Destroy(instance, _lifeTime);
        }
    }
}