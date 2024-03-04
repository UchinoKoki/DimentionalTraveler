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
        //シーンロード時の初期化処理
        if(ThisSceneState.instance.sceneType == SceneType.Title)
        {
            //タイトルシーンの初期化処理
            Cursor.lockState = CursorLockMode.None;

            //初期ステージ数を設定
            stageNum = 0;
        }
        else if(ThisSceneState.instance.sceneType == SceneType.BattleField)
        {
            //バトルフィールドシーンの初期化処理
            Cursor.lockState = CursorLockMode.None;
            
            stageNum += 1;
            //カーソルをロック
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if(ThisSceneState.instance.sceneType == SceneType.SelectAbility)
        {
            //アビリティ選択シーンの初期化処理
        }
        else if(ThisSceneState.instance.sceneType == SceneType.Result)
        {
            //リザルトシーンの初期化処理
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
