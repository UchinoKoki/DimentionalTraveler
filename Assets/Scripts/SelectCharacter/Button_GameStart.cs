using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fade;

public class Button_GameStart : MonoBehaviour
{
    [SerializeField] private List<GameObject> observeObjectList;
    [SerializeField] private string sceneName;
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
        if (_isComplete)
        {
            FadeManager.instance.FadeOut(Fade.FadeType.Normal);
            SendData();
            SceneManager.instance.LoadScene(sceneName);
        }
    }

    //データを保存するスクリプトへ送信する
    public void SendData()
    {
        if(OverSceneData.instance == null) Debug.LogError("OverSceneData not find");
        OverSceneData.instance.AbilityList = FindObjectOfType<PlayerAbility>().GetAbility();
        OverSceneData.instance.AbilityCost = FindObjectOfType<PlayerAbility>().AbilityCost;
    }
}
