using UnityEngine;

public class Card : MonoBehaviour
{
    string header;
    Sprite visual;
    string description;
    SOCardModifier modifier;

    public string Header { get { return header; } set { header = value; } }
    public Sprite Visual { get { return visual; } set { visual = value; } }
    public string Description { get { return description; } set { description = value; } }
    public SOCardModifier Modifier { get { return modifier; } set { modifier = value; } }

    public void Use()
    {

    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
