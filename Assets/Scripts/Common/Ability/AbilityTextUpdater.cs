using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AbilityTextUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI costText;
    public void UpdateText(string _nameText,string _costText)
    {
        nameText.text = _nameText;
        costText.text = "Cost:" + _costText;
    }
}
