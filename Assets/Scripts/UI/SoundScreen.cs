using Audio;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SoundScreen : MonoBehaviour
    {
        [SerializeField] private Slider _sfxSlider;
        [SerializeField] private Slider _musicSlider;
        [SerializeField] private Observer.Event _menuClicked;
        [SerializeField] private Observer.Event _clicked;

        private AudioPlayer _audioPlayer;

        private void Start()
        {
            _audioPlayer = AudioPlayer.Instance;
            _sfxSlider.value = _audioPlayer.SFXVolume;
            _musicSlider.value = _audioPlayer.MusicVolume;
        }

        public void SetSfxSoundVolume(float sfx)
        {
            _audioPlayer.ChangeSfxVolume(sfx);
        }
        
        public void SetMusicSoundVolume(float music)
        {
            _audioPlayer.ChangeMusicVolume(music);
        }
        
        public void GoToMenu()
        {
            _menuClicked.Occured();
            _clicked.Occured();
        }
    }
}