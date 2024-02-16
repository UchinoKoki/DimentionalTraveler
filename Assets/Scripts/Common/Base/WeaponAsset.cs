using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponAsset", menuName = "ScriptableObject/WeaponAsset", order = 0)]
public class WeaponAsset: ScriptableObject {
    public GameObject WeaponAssetObject;
    public string WeaponName;
    public int AttackPower; 
    public float AttackSpeed;
    public float AttackRange;
}
