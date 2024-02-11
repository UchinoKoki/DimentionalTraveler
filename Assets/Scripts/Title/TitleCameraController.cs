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

    public void IndicationTitle()
    {
        isIndication = true;
        // this.transform.DOMove(indicationAnchor.transform.position, 1f).SetEase(Ease.InOutCirc);
        // this.transform.DORotate(indicationAnchor.transform.rotation.eulerAngles, 1f).SetEase(Ease.Linear).OnComplete(() => {
        //     TitleManager.instance.OnCompleteIndication();
        // });
        TitleManager.instance.OnCompleteIndication();
    }
}
