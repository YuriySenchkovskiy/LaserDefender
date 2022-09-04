using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ScoreDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private float _speed;
        [SerializeField] private int _standartScoreForSpeed;

        private const string Format = "00000000";
        private Coroutine _currentCoroutine;
        private int _previousScore;
        private float _startSpeed;

        private void Awake()
        {
            _startSpeed = _speed;
        }

        public void SetPreviousScore(int previousScore)
        {
            _previousScore = previousScore;
        }
        
        public void SetScore(int score)
        {
            SetScoreValue(score);
        }
        
        private void SetScoreValue(int score)
        { 
            if (_currentCoroutine != null)
            {
                StopCoroutine(_currentCoroutine);
            }

            if (score - _previousScore > _standartScoreForSpeed)
            {
                var valueAdded = score - _previousScore;
                var multiplier = valueAdded / _standartScoreForSpeed;
                _speed *= multiplier;
            }

            _currentCoroutine = StartCoroutine(ChangeSliderValue(score));
        }
        
        private IEnumerator ChangeSliderValue(int score)
        {
            while (_previousScore != score)
            {
                _previousScore = Mathf.CeilToInt(Mathf.MoveTowards(_previousScore, 
                                                score, 
                                                Time.deltaTime * _speed));
                _scoreText.text = _previousScore.ToString(Format);
                
                yield return null;
            }

            _speed = _startSpeed;
        }
    }
}