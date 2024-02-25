using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    protected List<Enemy> enemyList = new List<Enemy>();
    protected WeaponAsset weaponAsset;
    private void Start() {

    }
    public virtual void Attack()
    {
        Debug.Log("BaseWeapon Attack");
    }
    public virtual void EndAttack()
    {
        Debug.Log("BaseWeapon EndAttack");
    }
    public void SetEnemyList(List<Enemy> _list)
    {
        enemyList = _list;
        Debug.Log($"SetEnemyList{enemyList.Count}");
    }
    public void RemoveEnemyList(Enemy _enemy)
    {
        enemyList.Remove(_enemy);
    }
    public WeaponAsset GetItem()
    {
        return weaponAsset = gameObject.GetComponent<KeepWeaponData>().WeaponAsset;
    }
    public float GetCoolTime()
    {
        return weaponAsset.coolTime;
    }
}
