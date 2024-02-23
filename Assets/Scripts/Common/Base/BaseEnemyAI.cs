using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseEnemyAI : MonoBehaviour
{
    //移動関連
    protected NavMeshAgent agent;
    protected GameObject targetObject;

    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float rotationSpeed;
    [SerializeField] protected float attackRange;
    [SerializeField] protected float attackSpeed;

    private Enemy enemy;

    private void Start() {
        //Agentの取得
        agent = GetComponent<NavMeshAgent>();
        
        //パラメータの取得
        enemy = GetComponent<Enemy>();
        moveSpeed = enemy.enemyAsset.moveSpeed;
        rotationSpeed = enemy.enemyAsset.rotationSpeed;
        attackRange = enemy.enemyAsset.attackRange;

        //パラメータの設定
        agent.speed = moveSpeed;
        agent.angularSpeed = rotationSpeed;
        agent.stoppingDistance = attackRange;
    }
    void FixedUpdate()
    {
        if(agent.remainingDistance < attackRange)
        {
            //攻撃処理
            // enemy.Attack();
        }
        else
        {
            if (targetObject == null) return;
            SetDistination(targetObject.transform.position);
        }
    }
    public virtual void CheckPriority(List<GameObject> _list)
    {
        //優先度の調査
        Debug.LogError("Set Priority");
    }
    public void SetDistination(Vector3 _pos)
    {
        //目的地の設定
        if(agent == null) agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(_pos);
    }
}
