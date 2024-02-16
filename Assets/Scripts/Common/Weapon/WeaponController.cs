using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField]private WeaponAsset leftWeaponAsset;   
    [SerializeField]private List<GameObject> weaponAnchor = new List<GameObject>();
    [SerializeField] private List<WeaponAsset> weaponAssetList = new List<WeaponAsset>();
    [SerializeField]private List<GameObject> weaponObjectList = new List<GameObject>();
    public int nowWeaponSlot = 0;
    public int nowMaxWeaponSlot = 2;

    public bool isScroll = false;                      //スクロール中かどうか

    public void Input0()
    {
        Debug.Log("InputLeftClick");
    }
    public void Input1()
    {
        Debug.Log("InputRightClick");
    }
    /// <summary>
    /// 武器を取得する
    /// </summary>
    /// <param name="_weaponObject"></param>
    public void GetWeapon(GameObject _weaponObject)
    {
        //武器を取得した際に、武器を持っていた場合は、その武器を捨てる
        DropWeapon(_weaponObject.transform.position);
        //武器の登録
        leftWeaponAsset = _weaponObject.GetComponent<KeepWeaponData>().WeaponAsset;
        weaponAssetList[nowWeaponSlot] = leftWeaponAsset;
        weaponObjectList[nowWeaponSlot] = Instantiate(leftWeaponAsset.WeaponAssetObject, weaponAnchor[0].transform.position, transform.rotation, weaponAnchor[0].transform);
        //取得した武器の削除
        Destroy(_weaponObject);
    }
    private void DropWeapon(Vector3 _beforItemPosition)
    {
        if (leftWeaponAsset == null) return;
        Instantiate(leftWeaponAsset.WeaponAssetObject, _beforItemPosition, transform.rotation);
    }
    public GameObject GetHandWeapon()
    {
        if(leftWeaponAsset == null)
        {
            return null;
        }
        return leftWeaponAsset.WeaponAssetObject;
    }
    public void ChangeWeapon(float way)
    {
        if(!isScroll)
        {
            isScroll = true;
            if(way > 0)
            {
                nowWeaponSlot++;
                if(nowWeaponSlot > nowMaxWeaponSlot - 1)
                {
                    nowWeaponSlot = 0;
                }
            }
            else if(way < 0)
            {
                nowWeaponSlot--;
                if(nowWeaponSlot < 0)
                {
                    nowWeaponSlot = nowMaxWeaponSlot - 1;
                }
            }
        }
        if(way == 0)
        {
            isScroll = false;
        }
        SetWeapon();
    }
    private void SetWeapon()
    {
        leftWeaponAsset = weaponAssetList[nowWeaponSlot];
        for(int i = 0; i < weaponObjectList.Count; i++)
        {
            if(weaponObjectList[i] == null) continue;
            Debug.Log($"{(nowWeaponSlot + i) % nowMaxWeaponSlot}");
            weaponObjectList[i].transform.position = weaponAnchor[(nowWeaponSlot + i) % nowMaxWeaponSlot].transform.position;
            weaponObjectList[i].transform.rotation = weaponAnchor[(nowWeaponSlot + i) % nowMaxWeaponSlot].transform.rotation;
            weaponObjectList[i].transform.parent = weaponAnchor[(nowWeaponSlot + i) % nowMaxWeaponSlot].transform;
        }
    }
}
