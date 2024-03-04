using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SceneState;

public class ThisSceneState : MonoBehaviour
{
    public string sceneName;
    public SceneType sceneType;

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
