using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAttackAreaTrigger : MonoBehaviour
{
    private List<GameObject> targetList = new List<GameObject>();   //ターゲットリスト

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        targetList.Add(other.gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        targetList.Remove(other.gameObject);
    }
    public List<GameObject> GetTargetList(){
        return targetList;
    }
}
