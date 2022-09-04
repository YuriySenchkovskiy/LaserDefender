using System.Collections.Generic;
using UnityEngine;

namespace Observer
{
    [CreateAssetMenu(fileName = "New event", menuName = "Game Event", order = 51)]
    public class Event : ScriptableObject
    {
        private List<EventListener> _eventListeners = new List<EventListener>();

        public void Register(EventListener listener)
        {
            _eventListeners.Add(listener);
        }
        
        public void UnRegister(EventListener listener)
        {
            _eventListeners.Remove(listener);
        }

        public void Occured()
        {
            foreach (var listener in _eventListeners)
            {
                listener.OnEventOccurs();
            }
        }
    }
}