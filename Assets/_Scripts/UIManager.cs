using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SOEvents;

public class UIManager : MonoBehaviour
{
    [SerializeField] VoidEvent onCardGenerate;
    [SerializeField] VoidEvent onCardSave;
    [SerializeField] VoidEvent onCardLoad;

    public void InvokeCardGenerate()
    {
        onCardGenerate.Invoke();
    }

    public void InvokeCardSave()
    {
        onCardSave.Invoke();
    }
    
    public void InvokeCardLoad()
    {
        onCardLoad.Invoke();
    }
}
