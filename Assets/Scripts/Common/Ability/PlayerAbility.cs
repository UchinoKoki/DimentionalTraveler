using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤーのアビリティを管理するクラス
public class PlayerAbility : MonoBehaviour
{
    private List<PlayerAbilityAsset> abilityList = new List<PlayerAbilityAsset>();
    [SerializeField] private int abilityCost;

    public void AddAbility(PlayerAbilityAsset ability)
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
    }
    public void RemoveAbility(PlayerAbilityAsset ability)
    {
        //コストを返却
        abilityCost += ability.useCost;
        //リストから削除
        abilityList.Remove(ability);
    }
    public List<PlayerAbilityAsset> GetAbility()
    {
        return abilityList;
    }
}
