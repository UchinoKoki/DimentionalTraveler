using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponListAsset", menuName = "ScriptableObject/WeaponListAsset", order = 0)]
public class WeaponListAsset : ScriptableObject
{
    public List<WeaponAsset> WeaponList;
}
