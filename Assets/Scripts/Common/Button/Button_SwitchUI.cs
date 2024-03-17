using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_SwitchUI : MonoBehaviour
{
    [SerializeField] private GameObject panelObjcet;
    public void OnClick(bool state)
    {
        panelObjcet.SetActive(state);
    }
}
