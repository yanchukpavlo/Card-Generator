using UnityEngine;

[CreateAssetMenu(fileName = "New Genetator Data", menuName = "Scriptable object/Genetator Data")]
public class SOCardGenetatorData : ScriptableObject
{
    public string[] headers;
    public Sprite[] visuals;
    public string[] descriptions;
    public SOCardModifier[] cardModifier;
}
