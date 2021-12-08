using UnityEngine;

[CreateAssetMenu(fileName = "New Card Modifier", menuName = "Scriptable object/Card Modifier")]
[System.Serializable]
public class SOCardModifier : ScriptableObject
{
    public CardModifier cardModifier;
    public int amount;
}
