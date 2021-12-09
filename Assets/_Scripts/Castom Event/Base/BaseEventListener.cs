using UnityEngine;
using UnityEngine.Events;

namespace SOEvents
{
    public abstract class BaseEventListener<T, GE, UER> : MonoBehaviour
        where GE : BaseGameEvent<T> where UER : UnityEvent<T>
    {
        [SerializeField]
        protected GE _GameEvent;
        public GE GameEvent { get { return _GameEvent; } }

        [SerializeField]
        protected UER _UnityEventResponse;
        public UER UnityEventResponse { get { return _UnityEventResponse; } set { _UnityEventResponse = value; } }


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

    public abstract class BaseEventListener<GE> : MonoBehaviour
        where GE : BaseGameEvent
    {
        [SerializeField]
        protected GE _GameEvent;
        public GE GameEvent
        {
            get { return _GameEvent; }
            set
            {
                _GameEvent = value;
                _GameEvent.EventListeners += OnEventRaised;
            }
        }

        [SerializeField]
        protected UnityAction _ActionEventResponse;
        public UnityAction ActionEventResponse { get { return _ActionEventResponse; } set { _ActionEventResponse = value; } }


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

        public void OnEventRaised()
        {
            if (_GameEvent != null) _ActionEventResponse.Invoke();
        }
    }
}
