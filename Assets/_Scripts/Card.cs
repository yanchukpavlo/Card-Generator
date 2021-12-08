using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    void Use()
    {

    }
}
