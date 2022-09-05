using TMPro;
using UnityEngine;

namespace UI
{
    public class GameOverScreen : MonoBehaviour
    {
        [Header("General")]
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _bestScoreText;
        [SerializeField] private TextMeshProUGUI _gameResultText;
        [SerializeField] private TextMeshProUGUI _tryAgainText;
        
        [SerializeField] private string _textForLose;
        [SerializeField] private string _textForWin;
        [SerializeField] private string _textForBestScore = "Your best result:\n";
        [SerializeField] private string _textForScore = "You scored:\n";
        [SerializeField] private string _numberFormat = "000000000";

        [Header("Events")] 
        [SerializeField] private Observer.Event _sceneLoaded;
        [SerializeField] private Observer.Event _playClicked;
        [SerializeField] private Observer.Event _menuClicked;
        [SerializeField] private Observer.Event _clicked;

        private void Start()
        {
            _sceneLoaded.Occured();
        }

        public void SetScore(int score)
        {
            _scoreText.text = _textForScore + score.ToString(_numberFormat);
        }

        public void SetBestScore(int bestScore)
        {
            _bestScoreText.text = _textForBestScore + bestScore.ToString(_numberFormat);
        }

        public void SetTitle(bool isWon)
        {
            _gameResultText.text = isWon ? _textForWin : _textForLose;
            _tryAgainText.gameObject.SetActive(!isWon);
        }

        public void Play()
        {
            _playClicked.Occured();
            _clicked.Occured();
        }

        public void GoToMenu()
        {
            _menuClicked.Occured();
            _clicked.Occured();
        }
    }
}