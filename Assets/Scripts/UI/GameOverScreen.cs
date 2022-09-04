using Controller;
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
        [SerializeField] private Observer.Event _playClicked;
        [SerializeField] private Observer.Event _menuClicked;
        [SerializeField] private Observer.Event _clicked;

        private ScoreKeeper _scoreKeeper;

        private void Awake()
        {
            _scoreKeeper = FindObjectOfType<ScoreKeeper>();
            SetLable();
        }

        private void Start()
        {
            _scoreText.text = _textForScore + _scoreKeeper.Score.ToString(_numberFormat);
            _bestScoreText.text = _textForBestScore + _scoreKeeper.GetBestScore().ToString(_numberFormat);
        }

        private void SetLable()
        {
            _gameResultText.text = _scoreKeeper.IsWon ? _textForWin : _textForLose;
            _tryAgainText.gameObject.SetActive(!_scoreKeeper.IsWon);
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