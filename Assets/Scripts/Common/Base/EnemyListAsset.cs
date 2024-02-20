using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyListAsset", menuName = "ScriptableObject/EnemyListAsset", order = 0)]
public class EnemyListAsset : ScriptableObject
{
    public List<EnemyAsset> EnemyList;
}
