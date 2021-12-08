public static class Helper
{
    public static T GetRandomEnum<T>()
    {
        System.Array A = System.Enum.GetValues(typeof(T));
        T V = (T)A.GetValue(UnityEngine.Random.Range(0, A.Length));
        return V;
    }

    public static T Randomize<T>(T[] values)
    {
        T V = (T)values.GetValue(UnityEngine.Random.Range(0, values.Length));
        return V;
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
