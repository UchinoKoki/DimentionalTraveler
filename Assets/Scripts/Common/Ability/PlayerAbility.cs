using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤーのアビリティを管理するクラス
public class PlayerAbility : MonoBehaviour
{
    private List<AbilityAsset> abilityList = new List<AbilityAsset>();
    [SerializeField] private int abilityCost;
    [SerializeField] private AbilityUI abilityUI;

    public void AddAbility(AbilityAsset ability)
    {
        //コストが足りない場合は追加しない
        if(abilityCost < ability.useCost)
        {
            Debug.Log("コストが足りません");
            return;
        }
        //コストを消費
        abilityCost -= ability.useCost;
        //リストに追加
        abilityList.Add(ability);
        //表示を更新
        UIUpdate();
    }
    public void RemoveAbility(AbilityAsset ability)
    {
        //コストを返却
        abilityCost += ability.useCost;
        //リストから削除
        abilityList.Remove(ability);
        //表示を更新
        UIUpdate();
    }
    public List<AbilityAsset> GetAbility()
    {
        return abilityList;
    }
    private void UIUpdate()
    {
        abilityUI.UpdateDatas(abilityList);
    }
}
