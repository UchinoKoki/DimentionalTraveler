using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : BaseWeapon
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    override public void Attack()
    {
        foreach(var enemy in enemyList)
        {
            //敵にダメージを与える
            enemy.Damage(GetItem().AttackPower,this.gameObject);
        }
    }
}
