using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤーのアビリティを管理するクラス
public class PlayerAbility : MonoBehaviour
{
    [SerializeField] private List<AbilityAsset> abilityList = new List<AbilityAsset>();
    [SerializeField] private int abilityCost;
    [SerializeField] private GameObject nowAbilityParent;

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
        //データ保持スクリプトへデータを送る
        foreach (var item in nowAbilityParent.GetComponentsInChildren<KeepAbilityData>())
        {
            if(item.Ability == null)
            {
                item.Ability = ability;
                break;
            }
        }
    }
    public void RemoveAbility(AbilityAsset ability)
    {
        if(ability == null)return;
        //コストを返却
        abilityCost += ability.useCost;
        //リストから削除
        abilityList.Remove(ability);
    }
    public List<AbilityAsset> GetAbility()
    {
        return abilityList;
    }
}
