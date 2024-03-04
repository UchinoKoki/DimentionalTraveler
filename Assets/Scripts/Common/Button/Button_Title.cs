using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fade;

public class Button_Title : MonoBehaviour
{
    [SerializeField] private string sceneName;
    public void OnClick()
    {
        FadeManager.instance.FadeOut(Fade.FadeType.Normal);
        SceneManager.instance.LoadScene(sceneName);
    }
}
