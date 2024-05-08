using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.Events;

//プレイヤーのアビリティを管理するクラス
public class PlayerAbility : MonoBehaviour
{
    [SerializeField] private List<AbilityAsset> abilityList = new List<AbilityAsset>();
    public int AbilityCost;
    [SerializeField] private GameObject nowAbilityParent;
    [SerializeField] private List<KeepAbilityData> keepAbilityDataList = new List<KeepAbilityData>();

    //アビリティがない場合のアビリティ
    private AsyncOperationHandle<AbilityAsset> handle;
    [SerializeField] private AbilityAsset noneAbility;

    [SerializeField] private UnityEvent instantiateList = new UnityEvent();
    
    void Start()
    {
        //初期化
        instantiateList.Invoke();
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
        Debug.Log("アビリティの追加を開始します");
        foreach (var item in keepAbilityDataList)
        {
            Debug.Log("アビリティを追加します");
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
    //アビリティのリストを取得
    public List<AbilityAsset> GetAbility()
    {
        return abilityList;
    }
}
