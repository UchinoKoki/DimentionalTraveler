using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    public void Set()
    {
        
    }
    public virtual void Attack()
    {
        Debug.Log("BaseWeapon Attack");
    }
}