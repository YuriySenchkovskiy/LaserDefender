using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthDisplay : MonoBehaviour
    {
        [SerializeField] private Slider _healthSlider;
        [SerializeField] private float _speed;
        
        private Coroutine _currentCoroutine;
        private float _previousHp;

        public void SetStartHealthValue(int value)
        {
            _healthSlider.maxValue = value;
            SetSliderValue(value);
        }

        public void SetHealthValue(int value)
        {
            _previousHp = _healthSlider.value;
            SetSliderValue(value);
        }
        
        private void SetSliderValue(int health)
        { 
            if (_currentCoroutine != null)
            {
                StopCoroutine(_currentCoroutine);
            }
            
            _currentCoroutine = StartCoroutine(ChangeSliderValue(health));
        }

        private IEnumerator ChangeSliderValue(int health)
        {
            while (_previousHp != health)
            {
                _previousHp = Mathf.MoveTowards(_previousHp, health, Time.deltaTime * _speed);
                _healthSlider.value = _previousHp;
                
                yield return null;
            }
        }
    }
}