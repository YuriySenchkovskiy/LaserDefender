using Controller;
using UnityEngine;
using Utils;

namespace Player
{
    public class SpawnPlayer : MonoBehaviour
    {
        private void Awake()
        {
            var playerController = FindObjectOfType<PlayerController>();
            SpawnUtils.Spawn(playerController.Player, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}