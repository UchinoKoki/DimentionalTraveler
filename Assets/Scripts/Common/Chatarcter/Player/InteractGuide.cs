using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//インタラクトガイドの挙動を管理するクラス
public class InteractGuide : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI interactText;    //インタラクトガイドのテキスト
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    public void SetInteractText(string _text)
    {
        if(_text == "" || _text == null)
        {
            interactText.text = "";
            return;
        }
        if(_text == "Player" || _text == "Enemy" || _text == "Ground")interactText.text = "";
        else interactText.text = _text + " : E";
    }
}
