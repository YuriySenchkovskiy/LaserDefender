using ObjectPool;
using UnityEngine;

namespace Utils
{
    public class DestroyEnterTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.GetComponent<PoolItem>())
            {
                return;
            }
            
            var poolItem = other.GetComponent<PoolItem>();
            poolItem.Release();
        }
    }
}