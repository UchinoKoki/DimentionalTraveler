using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [SerializeField] private Animator anim;  //プレイヤーのアニメーター
    private int attackCount;                //攻撃回数
    public void PlayerAttackAnim(bool _attack)
    {
        anim.SetBool("Attack",_attack);
    }

    public void PlayAnim(float _speed,float _moveX,float _moveY,bool _dash)
    {
        anim.SetFloat("Speed", _speed);
        anim.SetFloat("BlendSpeed", Mathf.Clamp((-Mathf.Abs(_moveX) + Mathf.Abs(_moveY) / 2) + 0.5f,0,1));
        anim.SetFloat("MoveX", _moveX / 2 + 0.5f);
        anim.SetFloat("MoveY", _moveY / 2 + 0.5f);
        anim.SetFloat("Dash", _dash ? 1 : 0);
    }
}
