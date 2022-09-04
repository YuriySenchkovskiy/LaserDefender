using System;
using UnityEngine;

namespace Player
{
    [Serializable]
    public struct PlayerDefinition
    {
        [SerializeField] private Sprite _sprite;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private string _name;
        [SerializeField] private bool _isSelected;
        
        public Sprite Sprite => _sprite;
        public GameObject Prefab => _prefab;
        public string Name => _name;
        public bool IsSelected
        {
            get => _isSelected;
            set => _isSelected = value;
        }
    }
}