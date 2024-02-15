using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの挙動を管理するクラス
/// </summary>
public class Player : MonoBehaviour
{
    [SerializeField] private GameObject  camera;        //プレイヤーのカメラ
    [SerializeField] private GameObject itemArea;    //アイテムを取得するエリア
    PlayerMove playerMove;                      //プレイヤーの移動を管理するクラス
    PlayerJump playerJump;                      //プレイヤーのジャンプを管理するクラス
    FootColliderObserver footColliderObserver;  //足元のコライダーの挙動を監視するクラス
    PlayerAnim playerAnim;                      //プレイヤーのアニメーションを管理するクラス
    CenterRay centerRay;                        //カメラの中心からレイを飛ばすクラス
    WeaponController weaponController;          //武器のコントローラー
    GetWeapon getWeapon;                        //武器を取得するクラス

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
        playerAnim = GetComponent<PlayerAnim>();
        weaponController = GetComponent<WeaponController>();
        getWeapon = itemArea.GetComponent<GetWeapon>();
        centerRay = camera.GetComponent<CenterRay>();
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
        SetAnim();
    }
    /// <summary>
    /// プレイヤーの重力を設定する
    /// </summary>
    private void Gravity()
    {
        //重力を追加
        rb.AddForce(Vector3.down * gravity, ForceMode.Acceleration);
    }
    /// <summary>
    /// プレイヤーのアニメーションを設定する
    /// </summary>
    private void SetAnim()
    {
        //プレイヤーのアニメーションを設定
        playerAnim.PlayAnim(Mathf.Clamp(Mathf.Abs(playerMove.GetMoveVelocity().x) + Mathf.Abs(playerMove.GetMoveVelocity().y),0,1), playerMove.GetMoveVelocity().x, playerMove.GetMoveVelocity().y, playerMove.isDash);
    }
    public void GetAnyItem()
    {
        Debug.Log(getWeapon.GetWeaponObject());
        //もしアイテムが武器の場合、武器を持ち変える
        if(getWeapon.GetWeaponObject() != null)
        {
            weaponController.GetWeapon(getWeapon.GetComponent<GetWeapon>().GetWeaponObject().GetComponent<KeepWeaponData>().WeaponAsset);
        }

    }
    private void DropWeapon()
    {
        //武器をドロップする
    }
}
