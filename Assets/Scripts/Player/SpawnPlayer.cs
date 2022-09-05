using UnityEngine;
using Utils;

namespace Player
{
    public class SpawnPlayer : MonoBehaviour
    {
        [SerializeField] private PlayerRepository _playerRepository;
        
        private void Awake()
        {
            SpawnUtils.Spawn(_playerRepository.Player, 
                            transform.position, 
                            Quaternion.identity);
            
            Destroy(gameObject);
        }
    }
}