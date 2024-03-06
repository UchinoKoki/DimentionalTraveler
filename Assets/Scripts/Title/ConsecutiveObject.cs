using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//　オブジェクトを連続で動かす
public class ConsecutiveObject : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;   //動かすオブジェクト
    [SerializeField] private float speed = 0.5f;     //動く速さ
    [SerializeField] private float createLength = 0f;//生成する長さ
    [SerializeField] private float returnLength = 0f;//戻る長さ

    private Vector2 defaultPosition;                 //初期位置
    private void Start() {
        //初期位置を保存
        defaultPosition = new Vector2(objects[0].transform.position.x,objects[0].transform.position.y);
    }

    private void FixedUpdate() {
        Move();    
    }

    private void Move()
    {
        //オブジェクトを動かす
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].transform.position += new Vector3(0, 0, -speed);
            if(objects[i].transform.position.z < returnLength) ReturnPosition(objects[i]);
        }
    }
    private void ReturnPosition(GameObject gameObject)
    {
        //閾値を超えたオブジェクトを初期位置に戻す
        gameObject.transform.position = new Vector3(defaultPosition.x,defaultPosition.y, createLength);
    }
}
