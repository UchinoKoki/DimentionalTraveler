using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField]private WeaponAsset leftWeaponAsset;                                    //左手の武器
    [SerializeField]private List<GameObject> weaponAnchor = new List<GameObject>();         //武器を持つアンカー
    [SerializeField] private List<WeaponAsset> weaponAssetList = new List<WeaponAsset>();   //武器のリスト
    [SerializeField]private List<GameObject> weaponObjectList = new List<GameObject>();     //武器のオブジェクトのリスト
    public int nowWeaponSlot = 0;                                                           //現在の武器のスロット
    public int nowMaxWeaponSlot = 2;                                                        //最大の武器のスロット

    public bool isScroll = false;                                                           //スクロール中かどうか

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
        weaponObjectList[nowWeaponSlot] = Instantiate(leftWeaponAsset.WeaponAssetObject, weaponAnchor[0].transform.position, weaponAnchor[0].transform.rotation, weaponAnchor[0].transform);

        //武器をマネージャーへ保存
        OverSceneData.instance.WeaponList = weaponAssetList;

        //取得したフィールド上オブジェクトの削除
        Destroy(_weaponObject);
    }
    /// <summary>
    /// 武器を捨てる
    /// </summary>
    private void DropWeapon(Vector3 _beforItemPosition)
    {
        if (leftWeaponAsset == null) return;
        Instantiate(leftWeaponAsset.WeaponAssetObject, _beforItemPosition, transform.rotation);
    }
    /// <summary>
    /// 手に持っている武器を返す
    /// </summary>
    /// <returns></returns>
    public GameObject GetHandWeapon()
    {
        if(leftWeaponAsset == null)
        {
            return null;
        }
        return leftWeaponAsset.WeaponAssetObject;
    }
    /// <summary>
    /// 武器を変更する
    /// </summary>
    /// <param name="way"></param>
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
    /// <summary>
    /// 武器をセットする
    /// </summary>
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
