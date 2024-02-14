using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootColliderObserver : MonoBehaviour
{
    Player player;                                      //プレイヤーの挙動を管理するクラス
    [SerializeField] private GameObject playerObject;   //プレイヤーのオブジェクト
    private void Start() {
        player = playerObject.GetComponent<Player>();   //プレイヤーの挙動を管理するクラスを取得
    }
    /// <summary>
    /// 地面に接触したときに呼び出される
    /// </summary>
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Ground"))   
        {
            player.ResetJumpCount();
            Debug.Log("Grounded");
        }   
    }
}
