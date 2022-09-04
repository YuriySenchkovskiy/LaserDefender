using UnityEngine;
using UnityEngine.Events;

namespace Observer
{
    public class EventListener : MonoBehaviour
    {
        public Event Event;
        public UnityEvent Response;

        private void OnEnable()
        {
            Event.Register(this);
        }

        private void OnDisable()
        {
            Event.UnRegister(this);
        }
        
        public void OnEventOccurs()
        {
            Response?.Invoke();
        }
    }
}