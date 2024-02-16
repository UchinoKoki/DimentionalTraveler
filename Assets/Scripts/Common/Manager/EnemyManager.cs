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
        enemyList.Add(_enemy);
    }
}
