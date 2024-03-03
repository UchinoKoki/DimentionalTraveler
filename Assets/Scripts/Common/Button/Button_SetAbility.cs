using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ボタンが持つアビリティを設定するクラス
public class Button_SetAbility : MonoBehaviour
{
    [SerializeField] private KeepAbilityData keepAbilityData;//データ保持クラス

    public void SetAbility(PlayerAbility playerAbility)
    {
        playerAbility.AddAbility(keepAbilityData.Ability);
        this.gameObject.GetComponent<Image>().sprite = keepAbilityData.Ability.abilityIcon;
    }
}
