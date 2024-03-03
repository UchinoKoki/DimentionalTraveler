using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

//プレイヤーのアビリティを管理するクラス
public class PlayerAbility : MonoBehaviour
{
    [SerializeField] private List<AbilityAsset> abilityList = new List<AbilityAsset>();
    public int AbilityCost;
    [SerializeField] private GameObject nowAbilityParent;

    //アビリティがない場合のアビリティ
    private AsyncOperationHandle<AbilityAsset> handle;
    private AbilityAsset noneAbility;
    
    async void Start()
    {
        handle = Addressables.LoadAssetAsync<AbilityAsset>("Assets/Data/Ability/Ab_None.asset");
        noneAbility = await handle.Task;
    }

    public void AddAbility(AbilityAsset ability)
    {
        //コストが足りない場合は追加しない
        if(AbilityCost < ability.useCost)
        {
            Debug.Log("コストが足りません");
            return;
        }
        //コストを消費
        AbilityCost -= ability.useCost;
        //リストに追加
        abilityList.Add(ability);
        //データ保持スクリプトへデータを送る
        foreach (var item in nowAbilityParent.GetComponentsInChildren<KeepAbilityData>())
        {
            if(item.Ability == null || item.Ability == noneAbility)
            {
                item.Ability = ability;
                item.gameObject.GetComponent<Image>().sprite = ability.abilityIcon;
                item.gameObject.GetComponent<AbilityTextUpdater>().UpdateText(ability.abilityName,ability.useCost.ToString());
                break;
            }
        }
    }
    public void RemoveAbility(AbilityAsset ability)
    {
        if(ability == null || ability == noneAbility)return;
        //コストを返却
        AbilityCost += ability.useCost;
        //リストから削除
        for(int i = 0; i < nowAbilityParent.transform.childCount; i++)
        {
            foreach (var item in nowAbilityParent.GetComponentsInChildren<KeepAbilityData>())
            {
                if(item.Ability == ability)
                {
                    abilityList.Remove(ability);
                    return;
                }
            }
        }
    }
    public List<AbilityAsset> GetAbility()
    {
        return abilityList;
    }
}
