using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UI_EmphasisIcon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DOScale(new Vector3(1.0f, 1.0f, 1.0f), 0.5f).SetLoops(-1, LoopType.Yoyo); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
