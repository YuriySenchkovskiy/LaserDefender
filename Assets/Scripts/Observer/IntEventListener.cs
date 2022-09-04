using UnityEngine;
using UnityEngine.Events;

namespace Observer
{
    public class IntEventListener : MonoBehaviour
    {
        public IntEvent Event;
        public UnityEvent<int> Response;

        private void OnEnable()
        {
            Event.Register(this);
        }

        private void OnDisable()
        {
            Event.UnRegister(this);
        }
        
        public void OnEventOccurs(int number)
        {
            Response?.Invoke(number);
        }
    }
}