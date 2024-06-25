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

    public List<float> volumeList = new List<float>();//0:Master,1:BGM,2:SE
    
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
            Application.targetFrameRate = 24;
            //タイトルシーンの初期化処理
            //カーソルを解放
            Cursor.lockState = CursorLockMode.None;
            //初期ステージ数を設定
            stageNum = 0;
            OverSceneData.instance.AbilityList = new List<AbilityAsset>();
            OverSceneData.instance.WeaponList = new List<WeaponAsset>();
            //要素数を指定したリセットができなかったためfor文で初期化
            for(int i = 0; i < 3; i++)
            {
                OverSceneData.instance.WeaponList.Add(null);
            }
        }
        else if(ThisSceneState.instance.sceneType == SceneType.BattleField)
        {
            Application.targetFrameRate = 60;
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
            Application.targetFrameRate = 30;
            //アビリティ選択シーンの初期化処理
            //カーソルを解放
            Cursor.lockState = CursorLockMode.None;
        }
        else if(ThisSceneState.instance.sceneType == SceneType.Result)
        {
            Application.targetFrameRate = 24;
            //リザルトシーンの初期化処理
            //カーソルを解放
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
