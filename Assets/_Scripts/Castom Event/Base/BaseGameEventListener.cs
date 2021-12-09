using UnityEngine;
using UnityEngine.Events;

namespace SOEvents
{
    public abstract class BaseGameEventListener<T, GE, UER> : MonoBehaviour
        where GE : BaseGameEvent<T> where UER : UnityEvent<T>
    {
        [SerializeField]
        protected GE _GameEvent;
        public GE GameEvent { get { return _GameEvent; } }

        [SerializeField]
        protected UER _UnityEventResponse;
        public UER UnityEventResponse { get { return _UnityEventResponse; } }


        private void OnEnable()
        {
            if (_GameEvent is null) return;
            _GameEvent.EventListeners += OnEventRaised;
        }

        private void OnDisable()
        {
            if (_GameEvent is null) return;
            _GameEvent.EventListeners -= OnEventRaised;
        }

        public void OnEventRaised(T item)
        {
            _UnityEventResponse.Invoke(item);
        }
    }
}
