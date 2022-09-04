using Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PlayerWidget : MonoBehaviour, IPlayerRenderer<PlayerDefinition>
    {
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private Button _selectButton;
        [SerializeField] private TextMeshProUGUI _buttonText;
        
        [SerializeField] private string _selectText;
        [SerializeField] private string _selectedText;
        [SerializeField] private Observer.IntEvent _buttonPressed;

        private PlayerDefinition _data;
        private int _index;
        
        public void SetDataInWidget(PlayerDefinition localInfo, int index)
        {
            _data = localInfo;
            _index = index;
            UpdateWidget();
        }

        public void SetButtonStatus(PlayerDefinition data)
        {
            _buttonText.text = data.IsSelected ? _selectedText : _selectText;
            _selectButton.interactable = !data.IsSelected;
        }
        
        public void OnClick()
        {
            _buttonPressed.Occured(_index);
        }

        private void UpdateWidget()
        {
            _image.sprite = _data.Sprite;
            _name.text = _data.Name;
            SetButtonStatus(_data);
        }
    }
}