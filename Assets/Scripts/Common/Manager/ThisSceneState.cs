using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SceneState;

public class ThisSceneState : MonoBehaviour
{
    //シーンの種類
    public string sceneName;
    public SceneType sceneType;

    //次のシーンの行き先
    public string nextSceneName;

    public static ThisSceneState instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        GameManager.instance.Load();
    }
}
