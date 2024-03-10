using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アイテムが浮いているように動かす
/// </summary>
public class FloatingItem : MonoBehaviour
{
    private Vector3 startPosition;//初期位置
    private float timer;//時間
    
    //状態管理
    public bool isFloating = true;
    public bool isRotating = true;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if(isFloating)transform.position = startPosition + Vector3.up * Mathf.Sin(timer);
        if(isRotating)transform.Rotate(0, 1, 0);
    }
}
