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

public struct Void { }

public struct Modifier
{
    public Modifier(CardModifier modifier, int amount)
    {
        this.modifier = modifier;
        this.amount = amount;
    }

    public CardModifier modifier;
    public int amount;
}

public struct CardData
{
    public CardData(string header, Sprite visual, string description, SOCardModifier modifier)
    {
        this.header = header;
        this.visual = visual;
        this.description = description;
        this.modifier = modifier;
    }

    public string header;
    public Sprite visual;
    public string description;
    public SOCardModifier modifier;
}
