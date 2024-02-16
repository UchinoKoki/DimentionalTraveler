using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    bool attack = false;
    BaseWeapon weapon;

    [SerializeField] private PlayerMeleeAttackArea attackArea;
    public void Attack(GameObject _weapon)
    {
        weapon = _weapon.GetComponentInChildren<BaseWeapon>();
        if (weapon == null) return;
        weapon.SetEnemyList(attackArea.GetEnemyList());
        weapon.Attack();
    }
    public void EndAttack()
    {
        bool attack = false;
        weapon.EndAttack();
    }
}
