using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSearchTrigger : MonoBehaviour
{
    private GameObject target;       //ターゲット
    public bool isTargetPlayer = true; //プレイヤーをターゲットにするか.機能として作るかもしれないのでpublic
    private List<GameObject> targetList = new List<GameObject>();   //ターゲットリスト
    private GameObject nearTarget;                                  //一番近いターゲット

    private BaseEnemyAI baseEnemyAI;    //敵AI
    private void Start() {
        baseEnemyAI = transform.parent.GetComponent<BaseEnemyAI>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        targetList.Add(other.gameObject);
        ScanningData();
    }
    private void ScanningData(){
        if(targetList.Count == 0) return;
        nearTarget = targetList[0];
        foreach(var target in targetList){
            //ターゲットが既に死んでいたらリストから削除
            if(target == null){
                targetList.Remove(target);
                continue;
            }
            
            //優先度の調査
            baseEnemyAI.CheckPriority(targetList);
        }
        target = nearTarget;
    }
}
