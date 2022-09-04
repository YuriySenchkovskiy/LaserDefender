using UnityEngine;

namespace Waves
{
    [CreateAssetMenu(fileName = Name, menuName = Name, order = 51)]
    public class WaveConfiguration : ScriptableObject
    {
        [SerializeField] private WaveDefinition[] _definitions;

        private const string Name = "Wave Configuration";
        public int StageCount => _definitions.Length;

        public WaveDefinition GetWave(int index)
        {
            if (index < _definitions.Length)
            {
                return _definitions[index];
            }

            return _definitions[0];
        }
    }
}