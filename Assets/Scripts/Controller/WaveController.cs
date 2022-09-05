using System.Threading.Tasks;
using UnityEngine;
using Waves;

namespace Controller
{
    public class WaveController : MonoBehaviour
    {
        [Header("General")]
        [SerializeField] private WaveConfiguration _waveConfiguration;
        [SerializeField] private WaveSpawner _waveSpawner;
        [SerializeField] private float _delayBeforeFirstSpawn;

        [Header("Events")]
        [SerializeField] private Observer.Event _counterEven;
        [SerializeField] private Observer.IntEvent _counterOdd;
        [SerializeField] private Observer.Event _counterLastEnded;
        
        private int _millisecondsDelay;
        private int _counter;
        private WaveDefinition _currentStage;

        private void Start()
        {
            _millisecondsDelay = Mathf.CeilToInt(_delayBeforeFirstSpawn * 1000);
            SetStage();
            SendEvent();
        }

        private async void SetStage()
        {
            if (!enabled)
            {
                return;
            }

            if (_counter == 0)
            { 
                await Task.Delay(_millisecondsDelay);
            }
                
            _currentStage = _waveConfiguration.GetWave(_counter);
            _waveSpawner.SetWave(_currentStage);

            while (_waveSpawner.WaveStatus != WaveStatus.End) 
            { 
                await Task.Yield();
            }
            
            await Task.Delay(_currentStage.BreaksAfterWave / 2);
            _counter++;
            SendEvent();
            await Task.Delay(_currentStage.BreaksAfterWave / 2);
            
            if (_counter == _waveConfiguration.StageCount)
            {
                return;
            }
            else
            {
                SetStage();
            }
        }

        private void SendEvent()
        {
            if (_counter == _waveConfiguration.StageCount)
            {
                _counterLastEnded.Occured();
            }
            else if ((_counter + 1) % 2 == 0)
            {
                _counterEven.Occured();
            }
            else if ((_counter + 1) % 2 != 0)
            {
                _counterOdd.Occured(_counter + 1);
            }
        }
    }
}