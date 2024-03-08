using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<BaseCharacter> enemyList = new List<BaseCharacter>();

    public static EnemyManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    public void AddEnemy(BaseCharacter _enemy)
    {
        var _setList = enemyList;
        _setList.Add(_enemy);
        enemyList = DeleteNullToList(_setList);
    }
    public void DelEnemy(BaseCharacter _enemy)
    {
        var _setList = enemyList;
        _setList.Remove(_enemy);
        enemyList = DeleteNullToList(_setList);
    }
    public List<BaseCharacter> GetEnemyList()
    {
        return DeleteNullToList(enemyList);
    }
    private List<BaseCharacter> DeleteNullToList(List<BaseCharacter> _enemyList)
    {
        _enemyList.RemoveAll(enemy => enemy == null);
        return _enemyList;
    }
}
