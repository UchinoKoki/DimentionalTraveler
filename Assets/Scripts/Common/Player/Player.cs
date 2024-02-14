using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの挙動を管理するクラス
/// </summary>
public class Player : MonoBehaviour
{
    PlayerMove playerMove;                      //プレイヤーの移動を管理するクラス
    PlayerJump playerJump;                      //プレイヤーのジャンプを管理するクラス
    FootColliderObserver footColliderObserver;  //足元のコライダーの挙動を監視するクラス
    CenterRay centerRay;                        //カメラの中心からレイを飛ばすクラス

    #region 動き
    Rigidbody rb;                               //プレイヤーのRigidbody
    public float gravity = 9.8f;                //重力
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        ///各クラスのコンポーネントを取得
        playerMove = GetComponent<PlayerMove>();
        footColliderObserver = GetComponent<FootColliderObserver>();
        playerJump = GetComponent<PlayerJump>();
        rb = GetComponent<Rigidbody>();

        //カーソルをロック
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ResetJumpCount()
    {
        //ジャンプ回数をリセット
        playerJump.ResetCount();
    }
    public void FixedUpdate()
    {
        Gravity();
    }
    private void Gravity()
    {
        //重力を追加
        rb.AddForce(Vector3.down * gravity, ForceMode.Acceleration);
    }
}
