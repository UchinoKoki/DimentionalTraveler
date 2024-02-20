using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopItem : MonoBehaviour
{
    public WeaponListAsset WeaponListAsset;
    private List<WeaponAsset> weaponList;
    private float height = 1.0f;

    private void Start() {
        //リストからウェポンを取得
        GetList();
        PopWeapon();
    }
    private void GetList()
    {
        weaponList = WeaponListAsset.WeaponList;
    }
    private void PopWeapon()
    {
        //リストからランダムでウェポンを取得
        int index = Random.Range(0, weaponList.Count);
        WeaponAsset weapon = weaponList[index];
        //ウェポンを生成
        GameObject weaponObject = Instantiate(weapon.WeaponAssetObject, transform.position + Vector3.up * height, Quaternion.identity);
    }
}
