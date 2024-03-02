using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// プレイヤーの挙動を管理するクラス
/// </summary>

public class Player : BaseCharacter
{
    [SerializeField] private GameObject  camera;     //プレイヤーのカメラ
    [SerializeField] private GameObject itemArea;    //アイテムを取得するエリア
    [SerializeField] private GameObject interactGuideObject;    //インタラクトガイドのオブジェクト
    PlayerMove playerMove;                      //プレイヤーの移動を管理するクラス
    PlayerJump playerJump;                      //プレイヤーのジャンプを管理するクラス
    FootColliderObserver footColliderObserver;  //足元のコライダーの挙動を監視するクラス
    PlayerAnim playerAnim;                      //プレイヤーのアニメーションを管理するクラス
    CenterRay centerRay;                        //カメラの中心からレイを飛ばすクラス
    WeaponController weaponController;          //武器のコントローラー
    GetWeapon getWeapon;                        //武器を取得するクラス
    PlayerAttack playerAttack;                  //プレイヤーの攻撃を管理するクラス
    InteractGuide interactGuide;                //インタラクトガイドの挙動を管理するクラス

    #region 動き
    Rigidbody rb;                               //プレイヤーのRigidbody
    public float gravity = 9.8f;                //重力
    #endregion

    #region 基本情報
    public int maxBaseHP = 100;                    //最大体力
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
        playerAttack = GetComponent<PlayerAttack>();
        centerRay = camera.GetComponent<CenterRay>();
        interactGuide = interactGuideObject.GetComponent<InteractGuide>();
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
        playerJump.ResetCount();
    }
    public void FixedUpdate()
    {
        Gravity();
        SetAnim();
        //インタラクトデータの表示
        interactGuide.SetInteractText(GetInteractData());
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
    public void GetAnyItem(InputAction.CallbackContext context)
    {
        //アイテムを取得する
        if(context.started)
        {
            PickUpWeapon();
        }
    }
    private void PickUpWeapon()
    {
        //もしアイテムが武器の場合、武器を持ち変える
        if(getWeapon.GetWeaponObject() != null)
        {
            GameObject nearObject = getWeapon.GetWeaponObject();
            weaponController.GetWeapon(nearObject);
            getWeapon.RemoveWeapon(nearObject);
        }
    }
    /// <summary>
    /// プレイヤーの移動処理
    /// </summary>
    /// <param name="context"></param>
    public void OnMove(InputAction.CallbackContext context)
    {
        playerMove.moveVelocity = context.ReadValue<Vector2>();
    }
    public void OnDash(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            playerMove.isDash = true;
        }
        if(context.canceled)
        {
            playerMove.isDash = false;
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
        if(context.started){
            playerJump.JumpAction();
        }
        if(context.canceled)
        {
            playerJump.FinishJump();
        }
    }
    /// <summary>
    /// 攻撃入力があったときに呼び出される
    /// </summary>
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (GetHandWeapon() == null) return;
        if(context.started)
        {
            playerAttack.Attack(GetHandWeapon());
            playerAnim.PlayerAttackAnim(true);
        }
        if(context.canceled)
        {
            playerAttack.EndAttack();
            playerAnim.PlayerAttackAnim(false);
        }
    }
    public void OnScroll(InputAction.CallbackContext context)
    {
        context.ReadValue<Vector2>();
        float scroll = context.ReadValue<Vector2>().y;
        weaponController.ChangeWeapon(scroll);
    }
    //手に持っている武器を取得
    private GameObject GetHandWeapon()
    {
        return weaponController.GetHandWeapon();
    }
    public void OnInteract(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            GameObject castItem = centerRay.CastRayCenterObject();
            if(castItem == null) return;
            if(castItem.CompareTag("Gate"))
            {
                castItem.GetComponent<GateProgress>().isGateCharging = true;
            }
        }
    }
    private string GetInteractData()
    {
        GameObject castItem = centerRay.CastRayCenterObject();
        if(castItem == null) return "";
        return castItem.tag;
    }
}
