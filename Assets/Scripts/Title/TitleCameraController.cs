using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//タイトルシーンのカメラの制御
public class TitleCameraController : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 0.25f; //回転速度
    [SerializeField] private GameObject indicationAnchor; //タイトルの表示位置
    bool isIndication = false; //タイトルの表示が開始しているかどうか
    void FixedUpdate()
    {
        RotateCamera();
    }

    void RotateCamera()
    {
        transform.Rotate(new Vector3(0, 0, rotateSpeed));
    }
}
