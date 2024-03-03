using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//ボタンが持つアビリティを設定するクラス
public class Button_SetAbility : MonoBehaviour
{
    [SerializeField] private KeepAbilityData keepAbilityData;//データ保持クラス
    AbilityTextUpdater textUpdater;

    void Start()
    {
        textUpdater = GetComponent<AbilityTextUpdater>();
        textUpdater.UpdateText(keepAbilityData.Ability.abilityName,keepAbilityData.Ability.useCost.ToString());
    }

    public void SetAbility(PlayerAbility playerAbility)
    {
        playerAbility.AddAbility(keepAbilityData.Ability);
    }
}
