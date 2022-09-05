using UnityEngine;
using UnityEngine.Events;

namespace Observer
{
    public class BoolEventListener : MonoBehaviour
    {
        public BoolEvent Event;
        public UnityEvent<bool> Response;

        private void OnEnable()
        {
            Event.Register(this);
        }

        private void OnDisable()
        {
            Event.UnRegister(this);
        }
        
        public void OnEventOccurs(bool status)
        {
            Response?.Invoke(status);
        }
    }
}