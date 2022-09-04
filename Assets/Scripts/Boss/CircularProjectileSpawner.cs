using System.Collections;
using ObjectPool;
using UnityEngine;

namespace Boss
{
    public class CircularProjectileSpawner : MonoBehaviour
    {
        [SerializeField] private CircularProjectileSettings _setting;

        private void Start()
        {
            StartCoroutine(SpawnProjectiles());
        }

        private IEnumerator SpawnProjectiles()
        {
            var sectorStep = 2 * Mathf.PI / _setting.BurstCount;
            
            while (enabled)
            {
                for (int i = 0, burstCount = 1; i < _setting.BurstCount; i++, burstCount++)
                {
                    var angle = sectorStep * i;
                    var direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
                
                    var instance = Pool.Instance.GetGameObject(_setting.Prefab,
                                            transform.position,
                                            Quaternion.identity);
         
                    
                    var projectile = instance.GetComponent<DirectionalProjectile>();
                    projectile.Launch(direction);

                    if (burstCount < _setting.ItemPerBurst)
                    {
                        continue;
                    }

                    burstCount = 0;
                    yield return new WaitForSeconds(_setting.Delay);
                } 
            }
        }
    }
}