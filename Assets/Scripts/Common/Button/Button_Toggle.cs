using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//ボタンを押すとオブジェクトの有効無効をトグルで切り替える
public class Button_Toggle : MonoBehaviour
{
    [SerializeField] private List<GameObject> _objectsToToggleOn = new List<GameObject>();//ボタンを押したときに有効化
    [SerializeField] private List<GameObject> _objectsToToggleOff = new List<GameObject>();//ボタンを押したときに無効化
    [SerializeField] private bool isOn = false;//現在が有効か無効か
    [SerializeField] private float duration = 0.25f; //アニメーションの時間

    private void Start() {
        foreach (var item in _objectsToToggleOn)
        {
            item.SetActive(false);
        }
    }

    public void OnPush()
    {
        if(isOn)
        {
            isOn = false;
        }
        else
        {
            isOn = true;
        }
        OnToggle();
    }
    private void OnToggle()
    {
        if(isOn)
        {
            foreach (var item in _objectsToToggleOn)
            {
                item.SetActive(true);
                item.gameObject.transform.localScale = Vector3.zero;
                item.gameObject.transform.DOScale(Vector3.one, duration);
            }
            foreach (var item in _objectsToToggleOff)
            {
                item.SetActive(false);
            }
        }
        else
        {
            foreach (var item in _objectsToToggleOn)
            {
                item.SetActive(false);
            }
            foreach (var item in _objectsToToggleOff)
            {
                item.SetActive(true);
            }
        }
    }
}
