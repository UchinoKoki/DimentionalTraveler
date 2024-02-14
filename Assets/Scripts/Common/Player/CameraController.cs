using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject camera;

    private void FixedUpdate() {
        RotateCharacter();
    }
    /// <summary>
    /// キャラクターをカメラの向きに合わせて回転させる
    /// </summary>
    public void RotateCharacter(){
        player.transform.eulerAngles = new Vector3(0,camera.transform.eulerAngles.y - 180,0);
    }
}
