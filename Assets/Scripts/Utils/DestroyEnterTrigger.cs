using ObjectPool;
using UnityEngine;

namespace Utils
{
    public class DestroyEnterTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.TryGetComponent(out PoolItem poolItem))
            {
                return;
            }
            
            poolItem.Release();
        }
    }
}