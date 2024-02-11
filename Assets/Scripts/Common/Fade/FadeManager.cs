using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum FadeType
{
    Normal
}
//フェードを管理する
public class FadeManager : MonoBehaviour
{
    [SerializeField] private GameObject fadePanel; //フェードするパネル

    public void FadeIn(float time)
    {

    }
}
