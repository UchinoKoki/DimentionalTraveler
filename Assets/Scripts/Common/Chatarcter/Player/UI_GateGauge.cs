using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_GateGauge : MonoBehaviour
{
    [SerializeField] private Slider gateGauge;

    public void SetGauge(float _value)
    {
        gateGauge.value = _value;
    }
}
