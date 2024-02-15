using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public void Attack()
    {
        BaseWeapon weapon = GetComponentInChildren<BaseWeapon>();
        weapon.Attack();
    }
}
