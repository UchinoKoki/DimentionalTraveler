using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemyのステータスを管理するクラス
/// </summary>
public class Enemy : BaseCharacter
{
    public EnemyAsset enemyAsset;
    public BaseEnemyAI enemyAI;
    public void Init(EnemyAsset _enemyAsset)
    {
        enemyAsset = _enemyAsset;
        hp = enemyAsset.hp;
        enemyAI = GetComponentInChildren<BaseEnemyAI>();
    }
    public void Move()  
    {
        //敵の移動処理
    }
    public void Attack()
    {
        //敵の攻撃処理
    }
    public void Dead()
    {
        //敵の死亡処理
    }
}
