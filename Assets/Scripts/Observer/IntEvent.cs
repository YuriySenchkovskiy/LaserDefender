using System.Collections.Generic;
using UnityEngine;

namespace Observer
{
    [CreateAssetMenu(fileName = "New int event", menuName = "Int event", order = 51)]
    public class IntEvent : ScriptableObject
    {
        private List<IntEventListener> _intEventListeners = new List<IntEventListener>();

        public void Register(IntEventListener listener)
        {
            _intEventListeners.Add(listener);
        }
        
        public void UnRegister(IntEventListener listener)
        {
            _intEventListeners.Remove(listener);
        }

        public void Occured(int number)
        {
            foreach (var listener in _intEventListeners)
            {
                listener.OnEventOccurs(number);
            }
        }
    }
}