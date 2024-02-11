using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Fade;

public class TitleManager : MonoBehaviour
{
    public static TitleManager instance;
    private void Awake() {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    }
    private void Start() {
        FadeManager.instance.FadeIn(Fade.FadeType.Normal);
    }
}
