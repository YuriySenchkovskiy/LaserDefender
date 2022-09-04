using System.Threading.Tasks;
using Player;
using UnityEngine;

namespace Controller
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerRepository _playerRepository;
        [SerializeField] private Observer.Event _playerSelectHandled;

        private const string PlayerKey = "player index";
        private int _playerIndex;
        private GameObject _player;

        public GameObject Player => _player;

        private void Awake()
        {
            _playerIndex = PlayerPrefs.GetInt(PlayerKey, 0);
            _player = _playerRepository.GetPlayer(_playerIndex);
            _playerRepository.SetPlayerChosen(_playerIndex);
        }

        public async void SetPlayerIndex(int index)
        {
            _playerRepository.SetPlayerChosen(index);
            _player = _playerRepository.GetPlayer(index);
            PlayerPrefs.SetInt(PlayerKey, index);

            while (!_playerRepository.IsHandledPlayer || !_playerRepository.IsHandledIndex)
            {
                await Task.Yield();
            }
            
            _playerSelectHandled.Occured();
        }
    }
}