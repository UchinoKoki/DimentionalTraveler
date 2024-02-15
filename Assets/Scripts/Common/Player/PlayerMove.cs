using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public float speed = 1f;                        //プレイヤーの移動速度
    private float actualSpeed;                      //実際のプレイヤーの移動速度
    Vector2 moveVelocity;  //プレイヤーの移動方向
    public bool isDash = false;                     //ダッシュ中かどうか

    Rigidbody rb;                                   //プレイヤーのRigidbody
    // Start is called before the first frame update
    void Start()
    {
        //Rigidbodyを取得
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate() {
        //プレイヤーの移動処理
        Move();
    }
    public float GetSpeed()
    {
        //プレイヤーの移動速度を取得
        float nowSpeed = moveVelocity.magnitude * speed;
        return nowSpeed;
    }

    /// <summary>
    /// プレイヤーの移動方向を取得
    /// </summary>
    /// <returns></returns>
    public Vector2 GetMoveVelocity(){
        return moveVelocity;
    }

    /// <summary>
    /// プレイヤーの移動処理
    /// </summary>
    /// <param name="context"></param>
    public void OnMove(InputAction.CallbackContext context)
    {
        moveVelocity = context.ReadValue<Vector2>();
    }
    public void OnDash(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            isDash = true;
        }
        if(context.canceled)
        {
            isDash = false;
        }
    }
    private void Move()
    {
        if (isDash && GetMoveVelocity().y >= 0.9f && GetMoveVelocity().x <= 0.1)
        {
            actualSpeed = speed * 1.5f;
        }
        else
        {
            actualSpeed = speed;
        }
        rb.velocity = transform.TransformDirection(-moveVelocity.x* actualSpeed,0f,-moveVelocity.y* actualSpeed);
    }

}
