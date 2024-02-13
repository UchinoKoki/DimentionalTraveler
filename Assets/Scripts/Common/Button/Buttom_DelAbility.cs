using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//アビリティを削除するボタン
public class Buttom_DelAbility : MonoBehaviour
{
    [SerializeField] private KeepAbilityData keepAbilityData;

    public void DelAbility(PlayerAbility playerAbility)
    {
        if(keepAbilityData)playerAbility.RemoveAbility(keepAbilityData.Ability);
        keepAbilityData.Ability = null;
    }
}
