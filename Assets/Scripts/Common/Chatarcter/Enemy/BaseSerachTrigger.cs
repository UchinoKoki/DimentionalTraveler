using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵がプレイヤーを見つけるためのトリガー
/// </summary>
public class BaseSearchTrigger : MonoBehaviour
{
    private GameObject target;                                                      //ターゲット
    public bool isTargetPlayer = true;                                              //プレイヤーをターゲットにするか.機能として作るかもしれないのでpublic
    
    //ターゲット
    [SerializeField]private List<GameObject> targetList = new List<GameObject>();   //ターゲットリスト
    private GameObject nearTarget;                                                  //一番近いターゲット

    private BaseEnemyAI baseEnemyAI;                                                //敵AI
    private void Start() {
        baseEnemyAI = transform.parent.GetComponent<BaseEnemyAI>();
    }
    
    private void FixedUpdate() {
        if(targetList.Count == 0) return;
        ScanningData(); 
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
            if (baseEnemyAI == null) baseEnemyAI = transform.parent.GetComponent<BaseEnemyAI>();    
            baseEnemyAI.CheckPriority(targetList);
        }
        target = nearTarget;
    }
}
