using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    protected List<Enemy> enemyList = new List<Enemy>();    //攻撃対象の敵リスト
    protected WeaponAsset weaponAsset;                      //武器のステータス

    ///攻撃の基底クラス
    public virtual void Attack()
    {
        Debug.Log("BaseWeapon Attack");
    }
    ///攻撃終了の基底クラス
    public virtual void EndAttack()
    {
        Debug.Log("BaseWeapon EndAttack");
    }
    /// <summary>
    /// 攻撃対象の敵リストを設定する
    /// </summary>
    public void SetEnemyList(List<Enemy> _list)
    {
        enemyList = _list;
    }
    /// <summary>
    /// 攻撃対象の敵リストから削除する
    /// </summary>
    public void RemoveEnemyList(Enemy _enemy)
    {
        enemyList.Remove(_enemy);
    }
    /// <summary>
    /// 武器のステータスを取得する
    /// </summary>
    public WeaponAsset GetItem()
    {
        return weaponAsset = gameObject.GetComponent<KeepWeaponData>().WeaponAsset;
    }
    /// <summary>
    /// 武器のクールタイムを取得する
    /// </summary>
    public float GetCoolTime()
    {
        return weaponAsset.coolTime;
    }
}
