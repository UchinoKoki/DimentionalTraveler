using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    private float speed;                                //プレイヤーの移動速度
    private float actualSpeed;                          //実際のプレイヤーの移動速度
    [System.NonSerialized]public Vector2 moveVelocity;  //プレイヤーの移動方向
    [System.NonSerialized]public bool isDash = false;   //ダッシュ中かどうか

    private Rigidbody rb;                                   //プレイヤーのRigidbody
    private PlayerState playerState;                        //プレイヤーのステータスを管理するクラス
    // Start is called before the first frame update
    void Start()
    {
        //Rigidbodyを取得
        rb = GetComponent<Rigidbody>();
        //プレイヤーのステータスを取得
        playerState = GetComponent<PlayerState>();
    }
    private void FixedUpdate() {
        //プレイヤーの移動処理
        Move();
    }
    public float GetSpeed()
    {
        //プレイヤーの移動速度を取得
        float nowSpeed = moveVelocity.magnitude;
        return nowSpeed;
    }

    /// <summary>
    /// プレイヤーの移動方向を取得
    /// </summary>
    /// <returns></returns>
    public Vector2 GetMoveVelocity(){
        return moveVelocity;
    }
    private void Move()
    {
        if (isDash && GetMoveVelocity().y >= 0.9f && GetMoveVelocity().x <= 0.1)
        {
            actualSpeed = playerState.moveSpeed() + playerState.dashSpeed();
        }
        else
        {
            actualSpeed = playerState.moveSpeed();
        }
        rb.velocity = transform.TransformDirection(-moveVelocity.x* actualSpeed,0f,-moveVelocity.y* actualSpeed);
    }

}
