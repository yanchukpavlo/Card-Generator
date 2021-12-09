using UnityEngine;
using System;
using UnityEngine.Events;

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

    [System.Serializable]
    public abstract class BaseGameEvent : ScriptableObject
    {
        public Action EventListeners = delegate { };

        public void Invoke()
        {
            EventListeners.Invoke();
        }
    }
}
