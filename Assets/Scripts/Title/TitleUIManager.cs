using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TitleUIManager : MonoBehaviour
{
    [SerializeField] private GameObject pushAnyKeyText;
    [SerializeField] private GameObject title;
    // Start is called before the first frame update
    void Start()
    {
        pushAnyKeyText.SetActive(true);
        title.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeLogoDispray()
    {
        pushAnyKeyText.SetActive(false);
        title.SetActive(true);
    }
}
