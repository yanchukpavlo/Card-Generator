using UnityEngine;
using UnityEngine.Events;

namespace SOEvents
{
    public abstract class BaseGameEventListener<T, E, UER> : MonoBehaviour, IGameEventListener<T> where E : BaseGameEvent<T> where UER : UnityEvent<T>
    {
        [SerializeField] E gameEvent;
        public E GameaEvent { get { return gameEvent; } set { gameEvent = value; } }

        [SerializeField] UER unityEventResponse;
        public UER UnityEventResponse { get {return unityEventResponse; } set { unityEventResponse = value; } }

        private void OnEnable()
        {
            if (gameEvent == null) return;
            GameaEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            if (gameEvent == null) return;
            GameaEvent.UnregisterListener(this);
        }

        public void OnEventRaised(T item)
        {
            if (unityEventResponse != null) unityEventResponse.Invoke(item);
        }
    }
}
