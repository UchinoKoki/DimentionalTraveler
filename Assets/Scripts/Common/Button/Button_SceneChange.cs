using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fade;

public class Button_SceneChange : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private Fade.FadeType fadeType;
    public void OnClick()
    {
        FadeManager.instance.FadeOut(fadeType);
        SceneManager.instance.LoadScene(sceneName);
    }
}
