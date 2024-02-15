using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWeapon : MonoBehaviour
{
    [SerializeField] private List<GameObject> canGetList = new List<GameObject>();
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.GetComponent<KeepWeaponData>() != null){
            canGetList.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.gameObject.GetComponent<KeepWeaponData>() != null){
            canGetList.Remove(other.gameObject);
        }
    }
    //一番近い武器を取得
    public GameObject GetWeaponObject(){
        if(canGetList.Count == 0){
            return null;
        }
        GameObject nearWeapon = canGetList[0];
        float nearDistance = Vector3.Distance(transform.position,canGetList[0].transform.position);

        for(int i = 1; i < canGetList.Count; i++){
            float distance = Vector3.Distance(transform.position,canGetList[i].transform.position);
            if(distance < nearDistance){
                nearWeapon = canGetList[i];
                nearDistance = distance;
            }
        }
        return nearWeapon;
    }
    public void RemoveWeapon(GameObject _weapon){
        canGetList.Remove(_weapon);
        Destroy(_weapon);
    }
}
