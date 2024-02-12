using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ボタンが持つアビリティを設定するクラス
public class Button_SetAbility : MonoBehaviour
{
    [SerializeField] private KeepAbilityData keepAbilityData;//データ保持クラス

    public void SetAbility(PlayerAbility playerAbility)
    {
        playerAbility.AddAbility(keepAbilityData.Ability);
    }
}
