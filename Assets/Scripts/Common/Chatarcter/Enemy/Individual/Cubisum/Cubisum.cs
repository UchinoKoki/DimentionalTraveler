using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubisum : BaseEnemyAI
{
    public override void CheckPriority(List<GameObject> _list)
    {
        if(_list.Count == 0) return;
        //優先度の調査
        GameObject nearTarget = _list[0];
        foreach(var target in _list){
            if(target == null){
                _list.Remove(target);
                continue;
            }
            if((transform.position - target.transform.position).sqrMagnitude < (transform.position - nearTarget.transform.position).sqrMagnitude){
                nearTarget = target;
            }
        }
        targetObject = nearTarget;
        base.SetDistination(nearTarget.transform.position);
    }
    public override void Attack()
    {
        Debug.Log("Cubisum Attack");
    }
}
