using SOEvents;
using UnityEngine;

public class Card : MonoBehaviour
{
    string header;
    Sprite visual;
    string description;
    SOCardModifier modifier;

    ActionListener actionCreateListener;
    ActionListener actionUseListener;
    CardModifierEvent eventAddPoint;

    public string Header { get { return header; } set { header = value; } }
    public Sprite Visual { get { return visual; } set { visual = value; } }
    public string Description { get { return description; } set { description = value; } }
    public SOCardModifier Modifier { get { return modifier; } set { modifier = value; } }

    private void Start()
    {
        actionUseListener = Helper.AddActionListener(gameObject, Resources.Load<ActionEvent>("Action Event Use"));
        actionUseListener.ActionEventResponse += Use;
        actionUseListener.ActionEventResponse += Destroy;

        eventAddPoint = Resources.Load<CardModifierEvent>("CardModifier Event  Add Point");
    }

    public void SetupCreateEvents(ActionEvent actionEvent)
    {
        actionCreateListener = Helper.AddActionListener(gameObject, actionEvent);
        actionCreateListener.ActionEventResponse += Destroy;
    }

    public void Use()
    {
        eventAddPoint.Invoke(modifier);
        Destroy();
    }

    public void Destroy()
    {
        actionCreateListener.GameEvent.EventListeners -= Destroy;
        actionUseListener.GameEvent.EventListeners -= Destroy;
        actionUseListener.GameEvent.EventListeners -= Use;
        Destroy(gameObject);
    }
}
