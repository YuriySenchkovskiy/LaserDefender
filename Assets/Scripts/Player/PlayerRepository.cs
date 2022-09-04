using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = Name, menuName = Name, order = 51)]
    public class PlayerRepository : ScriptableObject
    {
        [SerializeField] private PlayerDefinition[] _players;
        
        private const string Name = "Player Repository";
        private bool _isHandledPlayer;
        private bool _isHandledIndex;

        public bool IsHandledPlayer => _isHandledPlayer;
        public bool IsHandledIndex => _isHandledIndex;
        
        public PlayerDefinition[] Players => _players;

        public GameObject GetPlayer(int index)
        {
            _isHandledPlayer = false;
            
            if (index >= 0 && index < _players.Length)
            {
                _isHandledPlayer = true;
                return _players[index].Prefab;
            }

            _isHandledPlayer = true;
            return _players[0].Prefab;
        }

        public void SetPlayerChosen(int index)
        {
            _isHandledIndex = false;
                
            for (int i = 0; i < _players.Length; i++)
            {
                _players[i].IsSelected = i == index;
            }
            
            _isHandledIndex = true;
        }
    }
}