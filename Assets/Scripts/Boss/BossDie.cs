using UnityEngine;

namespace Boss
{
    public class BossDie : MonoBehaviour
    {
        [SerializeField] private Observer.Event _bossDie;

        public void GetEffect()
        {
            _bossDie.Occured();
        }
    }
}