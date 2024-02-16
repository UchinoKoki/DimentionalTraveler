using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponArea : MonoBehaviour
{
    [SerializeField] private GameObject cameraObject;  //プレイヤーのカメラ
    private void FixedUpdate()
    {
        transform.eulerAngles = cameraObject.transform.eulerAngles;
    }
}
