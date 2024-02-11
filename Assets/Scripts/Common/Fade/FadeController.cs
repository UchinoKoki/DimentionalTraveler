using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

//ノーマルフェード（Imageの透明度を変える）の管理
public partial class FadeController : MonoBehaviour
{
    [SerializeField] private Image fadePanel;

    public void FadeInNormal(){
        if(fadePanel == null) Debug.LogError("fadePanel is null");
        fadePanel.gameObject.SetActive(true);
        fadePanel.color = new Color(0, 0, 0, 0);
        fadePanel.DOFade(1, 1f);
    }
}
