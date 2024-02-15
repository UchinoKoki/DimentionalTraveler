using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    public virtual void Attack()
    {
        Debug.Log("BaseWeapon Attack");
    }
    public virtual void EndAttack()
    {
        Debug.Log("BaseWeapon EndAttack");
    }
}
