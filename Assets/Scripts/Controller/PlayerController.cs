using System.Threading.Tasks;
using Player;
using UnityEngine;

namespace Controller
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerRepository _playerRepository;
        [SerializeField] private Observer.Event _playerSelectHandled;

        private const string PlayerKey = "player_index";
        private int _playerIndex;

        private void Awake()
        {
            _playerIndex = PlayerPrefs.GetInt(PlayerKey, 0);
            _playerRepository.SetPlayer(_playerIndex);
            _playerRepository.SetPlayerChosen(_playerIndex);
        }

        public async void SetPlayerIndex(int index)
        {
            _playerRepository.SetPlayer(index);
            _playerRepository.SetPlayerChosen(index);
            PlayerPrefs.SetInt(PlayerKey, index);

            while (!_playerRepository.IsHandledPlayer || !_playerRepository.IsHandledIndex)
            {
                await Task.Yield();
            }
            
            _playerSelectHandled.Occured();
        }
    }
}