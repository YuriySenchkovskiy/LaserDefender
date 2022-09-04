using TMPro;
using UnityEngine;

namespace UI
{
    public class GameDisplay : MonoBehaviour
    { 
        [Header("Wave")] 
        [SerializeField] private TextMeshProUGUI _infoText;
        [SerializeField] private Animator _waveAnimator;
        [SerializeField] private string _waveText;
        [SerializeField] private string _bossText;
        [SerializeField] private string _winText;

        private static readonly int Show = Animator.StringToHash("show");

        public void SetWaveText(int number)
        {
            ShowInfo();
            _infoText.text = number + _waveText;
        }

        public void SetBossText()
        {
            ShowInfo();
            _infoText.text = _bossText;
        }

        public void SetWinText()
        {
            ShowInfo();
            _infoText.text = _winText;
        }

        private void ShowInfo()
        {
            _waveAnimator.SetTrigger(Show);
        }
    }
}