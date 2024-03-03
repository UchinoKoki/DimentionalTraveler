using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

//アビリティを削除するボタン
public class Buttom_DelAbility : MonoBehaviour
{
    [SerializeField] private KeepAbilityData keepAbilityData;

    //アビリティがない場合のアビリティ
    private AsyncOperationHandle<AbilityAsset> handle;
    private AbilityAsset noneAbility;
    
    async void Start()
    {
        handle = Addressables.LoadAssetAsync<AbilityAsset>("Assets/Data/Ability/Ab_None.asset");
        noneAbility = await handle.Task;
    }

    public void DelAbility(PlayerAbility playerAbility)
    {
        if(keepAbilityData)playerAbility.RemoveAbility(keepAbilityData.Ability);
        keepAbilityData.Ability = noneAbility;
        this.gameObject.GetComponent<KeepAbilityData>().Ability = noneAbility;
        this.gameObject.GetComponent<Image>().sprite = noneAbility.abilityIcon;
    }
}
