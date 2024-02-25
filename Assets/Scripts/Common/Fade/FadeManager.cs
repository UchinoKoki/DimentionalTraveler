using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FadeType
{
    Normal
}
//フェードを管理する
public class FadeManager : MonoBehaviour
{
    public static FadeManager instance; //シングルトン

    private FadeController fadeController; //フェードの制御クラス
    
    private void Awake() {
        //シングルトン
        if(instance == null){
            instance = this;
        }else{
            Destroy(this);
        }

        //フェードの制御クラスを取得
        fadeController = gameObject.GetComponent<FadeController>();
    }


    //フェードイン
    public void FadeIn(Fade.FadeType fadeType)
    {
        //フェードの種類によって処理を分ける
        if(fadeType == Fade.FadeType.Normal)
        {
            FadeInNormal();
        }
    }
    //フェードアウト
    public void FadeOut(Fade.FadeType fadeType)
    {
        //フェードの種類によって処理を分ける
        if(fadeType == Fade.FadeType.Normal)
        {
            FadeOutNormal();
        }
    }
    public void FadeInNormal()
    {
        fadeController.FadeInNormal();
    }
    //ノーマルフェード(Imageの透明度を変える)
    private void FadeOutNormal()
    {
        fadeController.FadeOutNormal();
    }
}
