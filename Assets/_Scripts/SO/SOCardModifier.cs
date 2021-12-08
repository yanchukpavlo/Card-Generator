using UnityEngine;

[CreateAssetMenu(fileName = "New Card Modifier", menuName = "Scriptable object/Card Modifier")]
public class SOCardModifier : ScriptableObject
{
    public CardModifier cardModifier;
    public int amount;
}
