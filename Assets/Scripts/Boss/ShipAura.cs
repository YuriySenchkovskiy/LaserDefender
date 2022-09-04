using UnityEngine;

namespace Boss
{
    public class ShipAura : MonoBehaviour
    {
        private BossDie _boss;
        
        private void Awake()
        {
            _boss = FindObjectOfType<BossDie>();
        }

        private void FixedUpdate()
        {
            transform.position = _boss.transform.position;
        }
    }
}