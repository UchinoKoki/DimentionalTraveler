using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopEnemy : MonoBehaviour
{
    public EnemyListAsset enemyListAsset;
    private List<EnemyAsset> enemyList;
    private float height = 5.0f;
    public bool isRegion = false;
    private void Start() {
        //リストからエネミーを取得
        GetList();
        if (isRegion) PopRegion();
        else Pop();
    }
    
    private void GetList()
    {
        enemyList = enemyListAsset.EnemyList;
    }
    private void Pop()
    {
        //リストからランダムでエネミーを取得
        int index = Random.Range(0, enemyList.Count);
        EnemyAsset enemy = enemyList[index];
        //エネミーを生成
        GameObject enemyObject = Instantiate(enemy.enemyObject, transform.position + Vector3.up * height, Quaternion.identity);
    }
    private void PopRegion()
    {
        //リストからランダムでエネミーを取得
        int index = Random.Range(0, enemyList.Count);
        EnemyAsset enemy = enemyList[index];
        //エネミーを生成
        GameObject middleenemyObject = Instantiate(enemy.enemyObject, transform.position + Vector3.up * height , Quaternion.identity);
        GameObject leftenemyObject = Instantiate(enemy.enemyObject, transform.position + Vector3.up * height + Vector3.left * 5f, Quaternion.identity);
        GameObject rightenemyObject = Instantiate(enemy.enemyObject, transform.position + Vector3.up * height + Vector3.right * 5f, Quaternion.identity);

    }
}
