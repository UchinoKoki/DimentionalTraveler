using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    public int hp;                      //体力

    public void Damage(int _damage)
    {
        hp -= _damage;
        if(hp <= 0)
        {
            Dead();
        }
    }
    public void Dead()
    {
        Destroy(gameObject);
    }
}
