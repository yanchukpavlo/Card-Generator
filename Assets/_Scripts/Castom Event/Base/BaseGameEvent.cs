using UnityEngine;
using System;

namespace SOEvents
{
    [System.Serializable]
    public abstract class BaseGameEvent<T> : ScriptableObject
    {
        public event Action<T> EventListeners = delegate { };

        public void Invoke(T item)
        {
            EventListeners(item);
        }
    }
}
