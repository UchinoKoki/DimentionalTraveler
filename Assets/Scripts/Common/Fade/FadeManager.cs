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
    private FadeController fadeController; //フェードの制御クラス

    void Start()
    {
        fadeController = gameObject.GetComponent<FadeController>();
    }
    public void FadeInNormal()
    {
        fadeController.FadeInNormal();
    }
}
