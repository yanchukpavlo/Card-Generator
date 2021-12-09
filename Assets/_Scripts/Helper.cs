using SOEvents;
using UnityEngine;

public static class Helper
{
    public static T GetRandomEnum<T>()
    {
        System.Array A = System.Enum.GetValues(typeof(T));
        T V = (T)A.GetValue(Random.Range(0, A.Length));
        return V;
    }

    public static T Randomize<T>(T[] values)
    {
        T V = (T)values.GetValue(Random.Range(0, values.Length));
        return V;
    }

    public static ActionListener AddActionListener(GameObject obj, ActionEvent actionEvent)
    {
        var actionListener = obj.AddComponent<ActionListener>();
        actionListener.GameEvent = actionEvent;

        return actionListener;
    }
}

public enum CardModifier
{
    Healing,
    Shield,
    Mana,
    Attack,
    Speed
}

namespace SOEvents
{
    [System.Serializable] public struct Void { }

    [System.Serializable] public struct Modifier 
    {
        public Modifier(CardModifier modifier, int amount)
        {
            this.modifier = modifier;
            this.amount = amount;
        }

        public CardModifier modifier;
        public int amount;
    }
}
