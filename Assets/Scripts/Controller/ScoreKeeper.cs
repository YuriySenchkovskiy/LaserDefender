using UnityEngine;

namespace Controller
{
    public class ScoreKeeper : MonoBehaviour
    {
        [SerializeField] private Observer.IntEvent _scoreChanged;
        [SerializeField] private Observer.IntEvent _previousScore;
        
        private const string BestResult = "best_result";
        private int _bestScore;
        private int _score;
        private bool _isWon;
        
        public int Score => _score;
        public bool IsWon => _isWon;

        public void ResetScore()
        {
            _score = 0;
            _isWon = false;
        }

        public void SetIsWonStatus()
        {
            _isWon = true;
        }
        
        public void ModifyScore(int value)
        {
            _previousScore.Occured(_score);
            _score += value;
            Mathf.Clamp(_score, 0, int.MaxValue);
            _scoreChanged.Occured(_score);
        }

        public int GetBestScore()
        {
            if (!PlayerPrefs.HasKey(BestResult))
            {
                _bestScore = _score;
                PlayerPrefs.SetInt(BestResult, _score);
            }
            else
            {
                _bestScore = PlayerPrefs.GetInt(BestResult);
            }

            if (_bestScore < _score)
            {
                PlayerPrefs.SetInt(BestResult, _score);
                _bestScore = _score;
            }

            return _bestScore;
        }
    }
}