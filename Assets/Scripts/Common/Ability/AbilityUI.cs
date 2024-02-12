using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityUI : MonoBehaviour
{
    //現在セットされているアビリティを表示するUIボタン
    [SerializeField]private List<KeepAbilityData> uiList = new List<KeepAbilityData>();

    public void SetUIList(KeepAbilityData keepAbilityData){
        uiList.Add(keepAbilityData);
    }
    public void UpdateDatas(List<AbilityAsset> list)
    {
        for(int i = 0; i < list.Count; i++)
        {
            uiList[i].Ability = list[i];
        }
    }
}
