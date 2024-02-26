using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemyのステータスを設定するクラス
/// </summary>
public class Enemy : BaseCharacter
{
    public EnemyAsset enemyAsset;                   //敵のステータス
    [SerializeField] protected BaseEnemyAI enemyAI; //敵のAI
    private void Start()
    {
        //ステータスの設定
        hp = enemyAsset.hp;
        enemyAI = GetComponent<BaseEnemyAI>();
        EnemyManager.instance.AddEnemy(this);
    }
}
