using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI hpMeshPro;
    [SerializeField] TextMeshProUGUI shieldMeshPro;
    [SerializeField] TextMeshProUGUI manaMeshPro;
    [SerializeField] TextMeshProUGUI attackMeshPro;
    [SerializeField] TextMeshProUGUI speedMeshPro;

    int hp;
    int shield;
    int mana;
    int attack;
    int speed;

    public void AddPoint(SOCardModifier cardModifier)
    {
        switch (cardModifier.cardModifier)
        {
            case CardModifier.Healing:
                hp += cardModifier.amount;
                hpMeshPro.text = hp.ToString();
                break;

            case CardModifier.Shield:
                shield += cardModifier.amount;
                shieldMeshPro.text = shield.ToString();
                break;

            case CardModifier.Mana:
                mana += cardModifier.amount;
                manaMeshPro.text = mana.ToString();
                break;

            case CardModifier.Attack:
                attack += cardModifier.amount;
                attackMeshPro.text = attack.ToString();
                break;

            case CardModifier.Speed:
                speed += cardModifier.amount;
                speedMeshPro.text = speed.ToString();
                break;
        }
    }
}
