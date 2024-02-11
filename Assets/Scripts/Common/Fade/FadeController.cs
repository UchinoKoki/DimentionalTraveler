using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

//ノーマルフェード（Imageの透明度を変える）の管理
public partial class FadeController : MonoBehaviour
{
    [SerializeField] private Image fadePanel;   //フェード用のパネル

    public void FadeInNormal(){
        if(fadePanel == null) Debug.LogError("fadePanel is null");//fadePanelがnullの場合はエラーを出す
        
        //フェードパネルをアクティブにして透明度を1にする
        fadePanel.gameObject.SetActive(true);
        fadePanel.color = new Color(0, 0, 0, 1);

        //透明度を1に変える
        fadePanel.DOFade(0, 1f).OnComplete(() => {
            SceneManager.instance.OnCompleteFade();//フェードの後シーン遷移の有無にかかわらず呼び出す
            fadePanel.gameObject.SetActive(false);
        });
    }
    //フェードアウト
    public void FadeOutNormal(){
        if(fadePanel == null) Debug.LogError("fadePanel is null");//fadePanelがnullの場合はエラーを出す
        
        //フェードパネルをアクティブにして透明度を0にする
        fadePanel.gameObject.SetActive(true);
        fadePanel.color = new Color(0, 0, 0, 0);

        //透明度を1に変える
        fadePanel.DOFade(1, 1f).OnComplete(() => {
            SceneManager.instance.OnCompleteFade();//フェードの後シーン遷移の有無にかかわらず呼び出す
        });
    }
}
