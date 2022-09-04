using UnityEngine;

namespace UI
{
    public class MainMenuScreen : MonoBehaviour
    {
        [SerializeField] private Observer.Event _playClicked;
        [SerializeField] private Observer.Event _musicSettingClicked;
        [SerializeField] private Observer.Event _quitClicked;
        [SerializeField] private Observer.Event _clicked;
        
        [SerializeField] private Observer.Event _selectPlayerCLicked;
        [SerializeField] private Observer.Event _thankYouClicked;
        [SerializeField] private GameObject _quitButton;

        private void Awake()
        {
            if (Application.platform == RuntimePlatform.WebGLPlayer)
            {
                _quitButton.SetActive(false);
            }
        }

        public void Play()
        {
            _playClicked.Occured();
            _clicked.Occured();
        }

        public void Quit()
        {
            _quitClicked.Occured();
            _clicked.Occured();
        }

        public void ShowSoundSetting()
        {
            _musicSettingClicked.Occured();
            _clicked.Occured();
        }
        
        public void ShowSelectPlayer()
        {
            _selectPlayerCLicked.Occured();
            _clicked.Occured();
        }
        
        public void ShowThanks()
        {
            _thankYouClicked.Occured();
            _clicked.Occured();
        }
    }
}