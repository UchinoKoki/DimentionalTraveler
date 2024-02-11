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

    private Vector2 defaultPosition;
    private void Start() {
        defaultPosition = new Vector2(objects[0].transform.position.x,objects[0].transform.position.y);
    }

    private void FixedUpdate() {
        Move();    
    }

    private void Move()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].transform.position += new Vector3(0, 0, -speed);
            if(objects[i].transform.position.z < returnLength) ReturnPosition(objects[i]);
        }
    }
    private void ReturnPosition(GameObject gameObject)
    {
        gameObject.transform.position = new Vector3(defaultPosition.x,defaultPosition.y, createLength);
    }
}
