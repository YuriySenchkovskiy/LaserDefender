using UI;
using UnityEngine;

namespace Controller
{
    public class LevelManager : MonoBehaviour
    {
        [Header("General")]
        [SerializeField] private float _loadGameOverTime = 2f;
        [SerializeField] private string _mainMenuScene = "MainMenu";
        [SerializeField] private string _gameScene = "Game";
        [SerializeField] private string _gameOverScene = "GameOver";
        
        [SerializeField] private string _soundSettingScene = "SoundSetting";
        [SerializeField] private string _playerSelectScene = "SelectPlayer";
        [SerializeField] private string _thanksScene = "Thanks";
        
        [Header("Score")]
        [SerializeField] private ScoreKeeper _scoreKeeper;
        
        [Header("Score")]
        [SerializeField] private LevelLoader _loader;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void LoadMenu()
        {
            _loader.LoadLevel(_mainMenuScene);
        }
        
        public void LoadGame()
        {
            _scoreKeeper.ResetScore();
            _loader.LoadLevel(_gameScene);
        }
        
        public void LoadGameOver()
        {
            Invoke(nameof(WaitAndLoad), _loadGameOverTime);
        }
        
        public void LoadSoundSetting()
        {
            _loader.LoadLevel(_soundSettingScene);
        }

        public void LoadSelectPlayer()
        {
            _loader.LoadLevel(_playerSelectScene);
        }
        
        public void LoadThanks()
        {
            _loader.LoadLevel(_thanksScene);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        private void WaitAndLoad()
        {
            _loader.LoadLevel(_gameOverScene);
        }
    }
}