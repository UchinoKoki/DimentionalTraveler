using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatePopEnemy : MonoBehaviour
{
    [SerializeField] private EnemyListAsset enemyListAsset;

    private float popTimer;
    [SerializeField] private float popTime;
    [SerializeField] private float popQuantity;
    public bool isOn = false;

    [SerializeField] private float popAreaRadius = 1f;

    private void FixedUpdate() {
        if (!isOn) return;
        if (popTimer > 0) {
            popTimer -= Time.deltaTime;
        } else {
            for (int i = 0; i < popQuantity; i++) {
                int randomIndex = Random.Range(0, enemyListAsset.EnemyList.Count);
                Vector3 _pos = new Vector3(transform.position.x + Random.Range(-popAreaRadius, popAreaRadius), transform.position.y, transform.position.z + Random.Range(-popAreaRadius, popAreaRadius));
                GameObject enemy = Instantiate(enemyListAsset.EnemyList[randomIndex].enemyObject, _pos, Quaternion.identity);
            }
            popTimer = popTime;
        }
    }
    public void TurnOnGate()
    {
        isOn = true;
    }
}
