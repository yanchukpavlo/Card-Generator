using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SOEvents;
using System;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    [Header("Evrnts")]
    [SerializeField] ActionEvent actionCardGenerate;
    [SerializeField] ActionEvent actionCardLoad;
    [SerializeField] ActionEvent actionCardUse;
    [Space]
    [SerializeField] VoidEvent voidCardGenerate;
    [SerializeField] VoidEvent voidCardSave;
    [SerializeField] VoidEvent voidCardLoad;

    public void InvokeCardGenerate()
    {
        actionCardGenerate.Invoke();
        voidCardGenerate.Invoke();
    }
    public void InvokeCardLoad()
    {
        actionCardLoad.Invoke();
        voidCardLoad.Invoke();
    }

    public void InvokeCardSave()
    {
        voidCardSave.Invoke();
    }

    public void InvokeCardUse()
    {
        actionCardUse.Invoke();
    }

}
