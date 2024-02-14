using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterRay : MonoBehaviour
{
    [SerializeField] private Player player;  //プレイヤーの挙動を管理するクラス

    /// <summary>
    /// カメラの中心からレイを飛ばし、その先の座標を返す
    /// </summary>
    /// <returns></returns>
    public Vector3 CastRayCenter()
    {
        Vector3 center = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = Camera.main.ScreenPointToRay(center);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            return hit.point;
        }
        return Vector3.zero;
    }
}
