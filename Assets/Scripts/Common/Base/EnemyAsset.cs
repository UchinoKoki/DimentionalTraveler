using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyAsset", menuName = "ScriptableObject/EnemyAsset", order = 0)]
public class EnemyAsset : ScriptableObject {
    public string enemyName;
    public int hp;
    public int attack;
    public GameObject enemyObject;
    public float moveSpeed;
    public float attackSpeed;
    public float attackRange;
}
