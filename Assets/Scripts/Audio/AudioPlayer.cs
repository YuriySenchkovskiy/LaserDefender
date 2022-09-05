using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Audio
{
    public class AudioPlayer : MonoBehaviour
    {
        [Header("Main")]
        [SerializeField] private AudioSource _mainAudioSource;
        [SerializeField] private AudioClip _mainClip;
        [SerializeField] private AudioClip _bossClip;
        [SerializeField] private float _targetTime = 5f;

        [Header("Shooting")]
        [SerializeField] private AudioClip _shootingClip;
        [SerializeField] [Range(0f, 1f)] private float _shootingVolume = 1f;
        
        [Header("Damage")] 
        [SerializeField] private AudioClip _damageClip;
        [SerializeField] [Range(0f, 1f)] private float _damageVolume = 1f;
        
        [Header("Click")] 
        [SerializeField] private AudioClip _clickClip;
        [SerializeField] [Range(0f, 1f)] private float _clickVolume = 1f;
        
        [Header("Select Player")] 
        [SerializeField] private AudioClip _playerSelectClip;
        [SerializeField] [Range(0f, 1f)] private float _playerSelectVolume = 1f;

        private const string SFXKey = "sfx";
        private const string MusicKey = "music";
        private float _targetSFXVolume;
        private float _targetMusicVolume;
        
        private float _startSfxVolume = 0.6f;
        private float _startMusicVolume = 0.8f;
        private bool _isChangedSound;

        public static AudioPlayer Instance;
        public float MusicVolume => _targetMusicVolume;
        public float SFXVolume => _targetSFXVolume;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            _targetSFXVolume = PlayerPrefs.GetFloat(SFXKey, _startSfxVolume);
            _targetMusicVolume = PlayerPrefs.GetFloat(MusicKey, _startMusicVolume);
            
            ChangeMusicVolume(_targetMusicVolume);
            ChangeSfxVolume(_targetSFXVolume);
        }

        public void PlayShootingClip()
        {
            PlayClip(_shootingClip, _shootingVolume);
        }
        
        public void PlayDamageClip()
        {
            PlayClip(_damageClip, _damageVolume);
        }
        
        public void PlayClickClip()
        {
            PlayClip(_clickClip, _clickVolume);
        }
        
        public void PlaySelectClip()
        {
            PlayClip(_playerSelectClip, _playerSelectVolume);
        }

        public void ChangeMusicVolume(float volume)
        {
            _targetMusicVolume = volume;
            _mainAudioSource.volume = volume;
            PlayerPrefs.SetFloat(MusicKey, volume);
        }

        public void ChangeSfxVolume(float volume)
        {
            _targetSFXVolume = volume;
            _shootingVolume = volume;
            _damageVolume = volume;
            _playerSelectVolume = volume;
            
            _clickVolume = volume;
            
            PlayerPrefs.SetFloat(SFXKey, volume);
        }

        public void PlayBossSound()
        {
            ChangeClip(_bossClip);
        }

        public void PlayMainSound()
        {
            ChangeClip(_mainClip);
        }

        private async void ChangeClip(AudioClip clip)
        {
            if (_mainAudioSource.clip == clip)
            {
                return;
            }
            
            ChangeVolume(_targetMusicVolume, 0);

            while (_isChangedSound == false)
            {
                await Task.Yield();
            }
            
            SetSound(clip);
            ChangeVolume(0, _targetMusicVolume);
        }

        private async void ChangeVolume(float from, float to)
        {
            float currentTime = 0;

            while (_mainAudioSource.volume != to)
            {
                currentTime += Time.deltaTime;
                _mainAudioSource.volume = Mathf.MoveTowards(from, to, currentTime / _targetTime);
                await Task.Yield();
            }

            _isChangedSound = !_isChangedSound;
        }
        
        private void SetSound(AudioClip clip)
        {
            _mainAudioSource.clip = clip;
            _mainAudioSource.Play();
        }

        private void PlayClip(AudioClip clip, float volume)
        {
            if (clip != null)
            {
                var cameraPosition = Camera.main.transform.position;
                AudioSource.PlayClipAtPoint(clip, cameraPosition, volume);
            }
        }
    }
}