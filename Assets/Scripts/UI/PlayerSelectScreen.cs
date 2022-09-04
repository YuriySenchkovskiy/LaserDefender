using Player;
using UnityEngine;

namespace UI
{
    public class PlayerSelectScreen : MonoBehaviour
    {
        [SerializeField] private Transform _content;
        [SerializeField] private PlayerWidget _playerWidget;
        [SerializeField] private PlayerRepository _repository;
        [SerializeField] private Observer.Event _menuClicked;
        [SerializeField] private Observer.Event _clicked;

        private DataGroup<PlayerDefinition, PlayerWidget> _dataGroup;

        private void Start()
        {
            _dataGroup = new DataGroup<PlayerDefinition, PlayerWidget>(_playerWidget, _content);
            _dataGroup.SetData(_repository.Players);
        }

        public void SetButtonData()
        {
            var widgets = GetComponentsInChildren<PlayerWidget>();

            for (int i = 0; i < widgets.Length; i++)
            {
                widgets[i].SetButtonStatus(_repository.Players[i]);
            }
        }
        
        public void GoToMenu()
        {
            _menuClicked.Occured();
            _clicked.Occured();
        }
    }
}