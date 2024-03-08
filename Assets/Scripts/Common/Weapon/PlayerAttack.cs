using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    bool attack = false;                //攻撃が押されているか
    BaseWeapon weapon;                  //武器
    private float attackCoolTimer = 0;  //攻撃のクールタイム
    private GameObject weaponObject;    //武器のオブジェクト

    public PlayerMeleeAttackArea attackArea;  //攻撃範囲

    /// <summary>
    /// 攻撃ボタンが押された時の処理
    /// </summary>
    public void Attack(GameObject _weapon)
    {
        attack = true;
        weaponObject = _weapon;
    }
    /// <summary>
    /// 攻撃ボタンが離された時の処理
    /// </summary>
    public void EndAttack()
    {
        attack = false;
        weapon.EndAttack();
    }

    private void FixedUpdate() {
        //攻撃

        //クールダウン
        if(attackCoolTimer > 0) attackCoolTimer -= Time.deltaTime;

        //攻撃が押されているか確認
        if(!attack) return;                     //攻撃が押されていない場合は処理を抜ける                                    
        if (attackCoolTimer > 0) return;        //クールダウン中は処理を抜ける
        weapon = weaponObject.GetComponentInChildren<BaseWeapon>();
        if (weapon != null) StartAttack();
    }

    private void StartAttack()
    {
        //攻撃処理
        weapon.SetEnemyList(attackArea.GetEnemyList());
        weapon.Attack();
        attackCoolTimer = weapon.GetCoolTime();
    }
}
