using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [SerializeField]private float baseMoveSpeed = 1f;              //プレイヤーの移動速度
    [System.NonSerialized]public float addMoveSpeed = 0f;          //ダッシュ時の追加速度
    
    [SerializeField]private float baseDashSpeed = 1.5f;            //ダッシュ時の基本追加速度
    [System.NonSerialized]public float addDashSpeed = 0f;          //ダッシュ時の追加速度

    /// <summary>
    /// プレイヤーの合計移動速度を取得
    /// </summary>
    public float moveSpeed()
    {
        return baseMoveSpeed + addMoveSpeed;
    }

    /// <summary>
    /// プレイヤーのダッシュ時の合計速度を取得
    /// </summary>  
    public float dashSpeed()
    {
        return baseDashSpeed + addDashSpeed;
    }
}
