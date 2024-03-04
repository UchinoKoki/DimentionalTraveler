using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SceneState;
using Fade;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int stageNum = 0;
    private string resultName = "Result";

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Load()
    {
        Initialization();
    }
    public void DeadPlayer(GameObject _player)
    {
        FadeManager.instance.FadeOut(Fade.FadeType.Normal);
        SceneManager.instance.LoadScene(resultName);
    }
    private void Initialization()
    {
        Debug.Log("Initialization");
        Debug.Log(ThisSceneState.instance.sceneType);
        //シーンロード時の初期化処理
        if(ThisSceneState.instance.sceneType == SceneType.Title)
        {
            //タイトルシーンの初期化処理
            //カーソルを解放
            Cursor.lockState = CursorLockMode.None;
            //初期ステージ数を設定
            stageNum = 0;
        }
        else if(ThisSceneState.instance.sceneType == SceneType.BattleField)
        {
            Debug.Log("BattleField");
            //バトルフィールドシーンの初期化処理
            //ステージ数を進める
            stageNum += 1;
            //武器の設定
            WeaponController  weaponController = FindObjectOfType<WeaponController>();
            weaponController.InitializeWeaponSet(OverSceneData.instance.WeaponList);
            //アビリティの設定
            
            //カーソルをロック
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if(ThisSceneState.instance.sceneType == SceneType.SelectAbility)
        {
            //アビリティ選択シーンの初期化処理
            //カーソルを解放
            Cursor.lockState = CursorLockMode.None;
        }
        else if(ThisSceneState.instance.sceneType == SceneType.Result)
        {
            //リザルトシーンの初期化処理
            //カーソルを解放
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
