using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoundText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI roundText;
    
    void Start()
    {
        SetRoundText();
    }
    public void SetRoundText()
    {
        roundText.text = "Round " + GameManager.instance.stageNum.ToString();
    }
}
