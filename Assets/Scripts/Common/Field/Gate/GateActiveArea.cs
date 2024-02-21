using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateActiveArea : MonoBehaviour
{
    GateProgress gateProgress;
    [SerializeField] private List<GameObject> targetList = new List<GameObject>();

    private void Start() {
        gateProgress = transform.parent.GetComponent<GateProgress>();
    }
    private void OnTriggerStay(Collider other) {
        //プレイヤー以外は無視
        if (!other.CompareTag("Player")) return;
        //リストに無ければ追加
        if(!targetList.Contains(other.gameObject)) targetList.Add(other.gameObject);
        //プレイヤーがいるならゲートチャージ
        gateProgress.Charge(true);
    }
    private void OnTriggerExit(Collider other) {
        if (!other.CompareTag("Player")) return;
        targetList.Remove(other.gameObject);
        foreach(var target in targetList){
            if(target == null){
                targetList.Remove(target);
                continue;
            }
            if(target.CompareTag("Player")) return;
        }
        gateProgress.Charge(false);
    }
}
