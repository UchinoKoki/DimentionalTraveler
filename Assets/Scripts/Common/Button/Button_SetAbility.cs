using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ボタンが持つアビリティを保持、設定するクラス
public class Button_SetAbility : MonoBehaviour
{
    [SerializeField]private PlayerAbilityAsset ability;
    public void SetAbility(PlayerAbility playerAbility)
    {
        playerAbility.AddAbility(ability);
    }
}
