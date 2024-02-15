using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponHand
{
    Left,
    Right
}

public class WeaponController : MonoBehaviour
{
    [SerializeField]private WeaponAsset leftWeaponAsset;   
    [SerializeField]private WeaponAsset rightWeaponAsset;
    private WeaponHand nowWeaponHand;

    public void Input0()
    {
        Debug.Log("InputLeftClick");
    }
    public void Input1()
    {
        Debug.Log("InputRightClick");
    }
    public void GetWeapon(WeaponAsset _weaponAsset)
    {
        if (nowWeaponHand == WeaponHand.Left)
        {
            leftWeaponAsset = _weaponAsset;
        }
        else if (nowWeaponHand == WeaponHand.Right)
        {
            rightWeaponAsset = _weaponAsset;
        }
        else
        {
            Debug.LogError("WeaponHand is not set");
        }
    }
}
