using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateActiveArea : MonoBehaviour
{
    GateProgress gateProgress;
    List<GameObject> targetList = new List<GameObject>();

    private void Start() {
        gateProgress = transform.parent.GetComponent<GateProgress>();
    }
    private void OnTriggerStay(Collider other) {
        if (!other.CompareTag("Player")) return;
        targetList.Add(other.gameObject);
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
