using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TutorialSelectCharacter : MonoBehaviour
{
    [SerializeField] private GameObject[] menuUI;
    float timer = 0.0f;
    [SerializeField]private float waitTime = 1.0f;
    [SerializeField]int menuNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        foreach(var menu in menuUI)
        {
            menu.SetActive(false);
        }
        ActiveMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if(timer > waitTime)
        {
            timer = 0.0f;
        }
    }

    public void ActiveMenu()
    {
        for(int i = 0; i < menuUI.Length; i++)
        {
            if(i == menuNum)
            {
                menuUI[i].SetActive(true);
                //アニメーション
                //均一の拡大量のため、空オブジェクトの子供にUIを置いて拡大すること
                menuUI[i].transform.DOScale(new Vector3(1.0f, 1.0f, 1.0f), 0.5f).SetEase(Ease.OutBounce);
            }
        }
    }
    public void DeActiveMenu(int thisNum)
    {
        if(menuNum != thisNum)return;
        for(int i = 0; i < menuUI.Length; i++)
        {
            if(i == menuNum)
            {
                menuUI[i].SetActive(false);
            }
        }
        menuNum++;
        if(menuUI.Length > menuNum)ActiveMenu();
    }
}
