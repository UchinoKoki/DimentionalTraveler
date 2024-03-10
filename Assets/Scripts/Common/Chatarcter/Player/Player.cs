using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// プレイヤーの挙動を管理するクラス
/// </summary>
public class Player : BaseCharacter
{
    [SerializeField] private GameObject  camera;                //プレイヤーのカメラ
    [SerializeField] private GameObject itemArea;               //アイテムを取得するエリア
    [SerializeField] private GameObject interactGuideObject;    //インタラクトガイドのオブジェクト

    private PlayerState playerState;                    //プレイヤーのステータスを管理するクラス
    private PlayerMove playerMove;                      //プレイヤーの移動を管理するクラス
    private PlayerJump playerJump;                      //プレイヤーのジャンプを管理するクラス
    private FootColliderObserver footColliderObserver;  //足元のコライダーの挙動を監視するクラス
    private PlayerAnim playerAnim;                      //プレイヤーのアニメーションを管理するクラス
    private CenterRay centerRay;                        //カメラの中心からレイを飛ばすクラス
    private WeaponController weaponController;          //武器のコントローラー
    private GetWeapon getWeapon;                        //武器を取得するクラス
    private PlayerAttack playerAttack;                  //プレイヤーの攻撃を管理するクラス
    private InteractGuide interactGuide;                //インタラクトガイドの挙動を管理するクラス

    #region 動き
    private Rigidbody rb;                               //プレイヤーのRigidbody
    public float gravity = 9.8f;                        //重力
    public bool canMove = true;
    #endregion

    #region 基本情報
    public int maxBaseHP = 100;                                          //最大体力の基礎数値
    [System.NonSerialized]public int abilityAddHP = 0;                   //アビリティによる体力の追加数値
    [System.NonSerialized]public int maxHP;                              //最大体力
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        ///各クラスのコンポーネントを取得
        playerState = GetComponent<PlayerState>();
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

        //最大体力を計算
        maxHP = maxBaseHP + abilityAddHP;    //最大体力
    }
    public void FixedUpdate()
    {
        Gravity();          //重力を追加
        SetAnim();          //プレイヤーのアニメーションを更新設定

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
    /// <summary>
    /// インタラクトボタンが押されたときに呼び出される
    /// </summary>
    public void OnInteract(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            GameObject castItem = centerRay.CastRayCenterObject();
            if(castItem == null) return;
            if (castItem.CompareTag("Gate"))
            {
                //ゲートにインタラクトする
                castItem.GetComponent<GateProgress>().Interact();
            }
            if(castItem.CompareTag("Ability"))
            {
                //アビリティアイテムを取得する
                castItem.GetComponent<AbilityItem>().GetAbilityItem(playerState.chooseAbilityNum, this);
            }
        }
    }
    /// <summary>
    /// プレイヤーの移動処理
    /// </summary>
    /// <param name="context"></param>
    public void OnMove(InputAction.CallbackContext context)
    {
        if(canMove && playerMove != null)playerMove.moveVelocity = context.ReadValue<Vector2>();
    }
    /// <summary>
    /// プレイヤーのダッシュ処理
    /// </summary>
    /// <param name="context"></param>
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
    /// ジャンプ処理
    /// </summary>
    /// <param name="context"></param>
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
    /// 攻撃
    /// 長押しで継続攻撃を実装するため、開始と終了でboolを切り替える
    /// </summary>
    public void OnAttack(InputAction.CallbackContext context)
    {
        //手に持っている武器がない場合は攻撃しない
        if (GetHandWeapon() == null) return;

        //攻撃ボタンが押されたとき
        if(context.started)
        {
            playerAttack.Attack(GetHandWeapon());
            playerAnim.PlayerAttackAnim(true);
        }
        //攻撃ボタンが離されたとき
        if(context.canceled)
        {
            playerAttack.EndAttack();
            playerAnim.PlayerAttackAnim(false);
        }
    }
    /// <summary>
    /// スクロール入力
    /// </summary>
    public void OnScroll(InputAction.CallbackContext context)
    {
        context.ReadValue<Vector2>();
        float scroll = context.ReadValue<Vector2>().y;
        //武器を持ち変える
        weaponController.ChangeWeapon(scroll);
    }
    //手に持っている武器を取得
    private GameObject GetHandWeapon()
    {
        return weaponController.GetHandWeapon();
    }

    /// <summary>
    /// プレイヤーのジャンプ回数をリセットする
    /// </summary>
    public void ResetJumpCount()
    {
        playerJump.ResetCount();
    }
    /// <summary>
    /// アイテムを取得する
    /// </summary>
    /// <param name="context">InputAction/Interact</param>
    public void GetAnyItem(InputAction.CallbackContext context)
    {
        //アイテムを取得する
        if(context.started)
        {
            PickUpWeapon();
        }
    }
    /// <summary>
    /// 落ちてる武器を拾う
    /// </summary>
    private void PickUpWeapon()
    {
        //もしアイテムが武器の場合、武器を持ち変える
        if(getWeapon.GetWeaponObject() != null)
        {
            //武器を取得
            GameObject nearObject = getWeapon.GetWeaponObject();
            //武器を持ち変える
            weaponController.GetWeapon(nearObject);
            getWeapon.RemoveWeapon(nearObject);
        }
    }
    /// <summary>
    /// 当たったオブジェクトのタグを取得する
    /// </summary>
    private string GetInteractData()
    {
        GameObject castItem = centerRay.CastRayCenterObject();
        if(castItem == null) return "";
        return castItem.tag;
    }
    /// <summary>
    /// プレイヤーのステータスを更新する
    /// </summary>
    public void UpdateStatus()
    {
        maxHP = maxBaseHP + abilityAddHP;
    }
}
