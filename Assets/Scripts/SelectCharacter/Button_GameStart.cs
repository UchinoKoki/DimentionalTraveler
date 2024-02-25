using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_GameStart : MonoBehaviour
{
    [SerializeField] private List<GameObject> observeObjectList;
    public void OnClick()
    {
        Debug.Log("Button_GameStart OnClick");
        //シーン遷移
        if(SceneManager.instance == null) Debug.LogError("SceneManager not find");
        bool _isComplete = true;
        foreach (var item in observeObjectList)
        {
            if(item.activeSelf == true) _isComplete = false;
        }
        if(_isComplete)SceneManager.instance.LoadScene("DemoStage");
    }
}
