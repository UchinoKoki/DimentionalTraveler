using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultAbilityText : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> abilityTexts;

    void Start()
    {
        SetAbilityTexts(OverSceneData.instance.AbilityList);
    }
    private void SetAbilityTexts(List<AbilityAsset> abilityList)
    {
        for(int i = 0; i < abilityList.Count; i++)
        {
            abilityTexts[i].text = abilityList[i].abilityName;
        }
    }
}
