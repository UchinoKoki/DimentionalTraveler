using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseEnemyAI : MonoBehaviour
{
    protected NavMeshAgent agent;
    protected GameObject targetObject;
    [SerializeField]protected GameObject attackObject;

    protected float moveSpeed;
    protected float rotationSpeed;
    protected float attackRange;
    protected float attackSpeed;
    protected int attackPower;

    protected float attackCoolTimer = 0;
    private Enemy enemy;

    private void Start() {
        //Agentの取得
        agent = GetComponent<NavMeshAgent>();
        
        //パラメータの取得
        enemy = GetComponent<Enemy>();
        moveSpeed = enemy.enemyAsset.moveSpeed;
        rotationSpeed = enemy.enemyAsset.rotationSpeed;
        attackRange = enemy.enemyAsset.attackRange;
        attackSpeed = enemy.enemyAsset.attackSpeed;
        attackPower = enemy.enemyAsset.attack;

        //パラメータの設定
        agent.speed = moveSpeed;
        agent.angularSpeed = rotationSpeed;
        agent.stoppingDistance = attackRange;
    }
    void FixedUpdate()
    {
        //距離で攻撃確認
        if(agent.remainingDistance < attackRange && attackCoolTimer <= 0)
        {
            //攻撃処理
            Attack();
            attackCoolTimer = attackSpeed;
        }
        else
        {
            if (targetObject == null) return;
            SetDistination(targetObject.transform.position);
        }

        //攻撃クールダウン
        if(attackCoolTimer > -1) attackCoolTimer -= Time.deltaTime;
    }
    public virtual void CheckPriority(List<GameObject> _list)
    {
        //優先度の調査
        Debug.LogError("Set Priority");
    }
    public virtual void Attack()
    {
        Debug.LogWarning("Attack is not override");
    }
    public void SetDistination(Vector3 _pos)
    {
        //目的地の設定
        if(agent == null) agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(_pos);
    }
    public List<GameObject> GetTargetList()
    {
        //ターゲットリストの取得
        BaseAttackAreaTrigger attackArea = attackObject.GetComponent<BaseAttackAreaTrigger>();
        return attackArea.GetTargetList();
    }
}
