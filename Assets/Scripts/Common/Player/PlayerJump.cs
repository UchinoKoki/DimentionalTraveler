using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpPower = 5.0f;        //1フレームで上昇する力
    private bool isGrounded;                                //地面に接地しているかどうか
    [SerializeField] private bool isJumping;                //ジャンプ中かどうか
    [SerializeField] private float jumpTimeCounter;                          //ジャンプする時間のカウンター
    [SerializeField] private float jumpTime;                //ジャンプする時間
    public int MaxJumpCount;                                //ジャンプした回数
    [SerializeField]private int jumpCount;                  //ジャンプした回数
    Rigidbody rb;                                           //プレイヤーのRigidbody

    private void Start() {  
        jumpCount = MaxJumpCount;               //ジャンプ回数をリセット
        rb = GetComponent<Rigidbody>();         //Rigidbodyを取得
        jumpTimeCounter = jumpTime;             //ジャンプ時間を設定
    }
    void FixedUpdate()
    {
        if(isJumping && jumpTimeCounter > 0){
            Jump();
            jumpTimeCounter -= Time.deltaTime;
        }
    }
    /// <summary>
    /// ジャンプボタンが押されたときに呼び出される
    /// </summary>
    /// <param name="context">
    /// InputSystemのコンテキスト
    /// </param>
    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.started && jumpCount > 0){
            jumpCount--;
            isJumping = true;
            jumpTimeCounter = jumpTime;
        }
        if(context.canceled && isJumping)
        {
            isJumping = false;
        }
    }
    /// <summary>
    /// ジャンプする処理
    /// </summary>
    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpPower, ForceMode.Acceleration);
    }
    /// <summary>
    /// ジャンプ回数をリセットする
    /// FootColliderObserverからPlayer経由で呼び出し。
    /// </summary>
    public void ResetCount()
    {
        jumpCount = MaxJumpCount;
        jumpTimeCounter = jumpTime;
    }
}
