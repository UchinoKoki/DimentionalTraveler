using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepWeaponData : MonoBehaviour
{
    [SerializeField] private WeaponAsset weaponAsset;
    public WeaponAsset WeaponAsset { get { return weaponAsset; } }
}
