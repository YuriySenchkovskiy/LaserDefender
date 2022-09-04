using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class DataGroup<T, P> where P : MonoBehaviour, IPlayerRenderer<T>
    {
        private readonly List<P> _createdItems = new List<P>();
        private readonly P _prefab;
        private readonly Transform _container;

        public DataGroup(P prefab, Transform container)
        {
            _prefab = prefab;
            _container = container;
        }

        public virtual void SetData(IList<T> data)
        {
            for (var i = _createdItems.Count; i < data.Count; i++)
            {
                var item = Object.Instantiate(_prefab, _container);
                _createdItems.Add(item);
            }
            
            for (var i = 0; i < data.Count; i++)
            {
                _createdItems[i].SetDataInWidget(data[i], i); 
                _createdItems[i].gameObject.SetActive(true);
            }
            
            for (var i = data.Count; i < _createdItems.Count; i++)
            {
                _createdItems[i].gameObject.SetActive(false);
            }
        }
    }
}