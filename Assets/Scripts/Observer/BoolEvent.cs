using System.Collections.Generic;
using UnityEngine;

namespace Observer
{
    [CreateAssetMenu(fileName = "New bool event", menuName = "Bool event", order = 51)]
    public class BoolEvent : ScriptableObject
    {
        private List<BoolEventListener> _boolEventListeners = new List<BoolEventListener>();

        public void Register(BoolEventListener listener)
        {
            _boolEventListeners.Add(listener);
        }
        
        public void UnRegister(BoolEventListener listener)
        {
            _boolEventListeners.Remove(listener);
        }

        public void Occured(bool status)
        {
            foreach (var listener in _boolEventListeners)
            {
                listener.OnEventOccurs(status);
            }
        }
    }
}