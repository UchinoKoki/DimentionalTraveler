using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpPower = 5.0f;//1フレームで上昇する力
    private bool isGrounded;                //地面に接地しているかどうか
    [SerializeField] private bool isJumping;//ジャンプ中かどうか
    [SerializeField] private float jumpTime;//ジャンプする時間
    private float jumpTimeCounter;          //ジャンプする時間のカウンター
    public int MaxJumpCount;                   //ジャンプした回数
    private int jumpCount;                  //ジャンプした回数

    private void Start() {
        jumpTimeCounter = jumpTime;
        jumpCount = MaxJumpCount;
    }
    private void FixedUpdate()
    {
        if(isJumping){
            if(jumpTimeCounter > 0)
            {
                Jump();
                Debug.Log("Jump");
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
                jumpTimeCounter = jumpTime;
            }
        }
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            Debug.Log("JumpStart");
            isJumping = true;
        }
        if(context.canceled)
        {
            Debug.Log("JumpEnd");
            jumpCount -= 1;
            isJumping = false;
        }
    }
    private void Jump()
    {
        transform.Translate(0, jumpPower, 0);
    }
}
