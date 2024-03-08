using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial  class EnhancementByAbility : MonoBehaviour
{
    [SerializeField]private Player player;

    void Start()
    {
        Enhancement();
    }

    public void Enhancement()
    {
        int _addHP = 0;
        int _addAttack = 0;
        int _addSpeed = 0;

        //アビリティの効果を取得
        foreach(var ability in OverSceneData.instance.AbilityList)
        {
            if(ability == null) continue;
            if(ability.abilityName == "BoostHP")
            {
                _addHP += ability.abilityValue;
            }
            if(ability.abilityName == "BoostAttack")
            {
                _addAttack += ability.abilityValue;
            }
            if(ability.abilityName == "BoostSpeed")
            {
                _addSpeed += ability.abilityValue;
            }
        }

        //アビリティの効果を加算
        player.abilityAddHP = _addHP;
        player.Heal(_addHP);

        //TODO:追加攻撃力を加算
        //TODO:追加スピードを加算

        //ステータスの変更を更新
        player.UpdateStatus();
    }
}
