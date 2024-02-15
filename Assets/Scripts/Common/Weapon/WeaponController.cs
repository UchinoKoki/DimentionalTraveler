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
    public void GetWeapon(GameObject _weaponObject)
    {
        if (nowWeaponHand == WeaponHand.Left)
        {
            if(leftWeaponAsset != null)
            {
                DropWeapon(_weaponObject.transform.position);
            }
            leftWeaponAsset = _weaponObject.GetComponent<KeepWeaponData>().WeaponAsset;
        }
        else if (nowWeaponHand == WeaponHand.Right)
        {
            if(rightWeaponAsset != null)
            {
                DropWeapon(_weaponObject.transform.position);
            }
            rightWeaponAsset = _weaponObject.GetComponent<KeepWeaponData>().WeaponAsset;
        }
        else
        {
            Debug.LogError("WeaponHand is not set");
        }
    }
    private void DropWeapon(Vector3 _beforItemPosition)
    {
        if (nowWeaponHand == WeaponHand.Left)
        {
            Instantiate(leftWeaponAsset.WeaponAssetObject, _beforItemPosition, transform.rotation);
        }
        else if (nowWeaponHand == WeaponHand.Right)
        {
            Instantiate(leftWeaponAsset.WeaponAssetObject, _beforItemPosition, transform.rotation);
        }
        else
        {
            Debug.LogError("WeaponHand is not set");
        }
    }
}
