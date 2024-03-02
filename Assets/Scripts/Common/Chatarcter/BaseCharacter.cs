using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using DG.Tweening;
using TMPro;
using UnityEngine.Events;

//参照サイト
//https://kingmo.jp/kumonos/unity-addressables-brief-summary/
public class BaseCharacter : MonoBehaviour
{
    public int hp;                      //体力
    private GameObject damageCanvas;    //ダメージエフェクト
    [SerializeField] private UnityEvent damageEvent = new UnityEvent();    //ダメージを受けた時に呼び出すイベント

    //OverRide先で多くの場合Startを使うため、Start使用時は注意

    //ダメージを受けたときのエフェクトまた計算処理
    public void Damage(int _damage,GameObject _attacker)
    {
        //ダメージエフェクトの生成
        Addressables.InstantiateAsync("Assets/Prefabs/DamageCanvas.prefab").Completed += (obj) =>
        {
            damageCanvas = obj.Result;
            damageCanvas.transform.position = this.transform.position + new Vector3(0, 5, 0);
            damageCanvas.transform.Find("DamageText").GetComponent<TextMeshProUGUI>().text = _damage.ToString();
            damageCanvas.GetComponent<DamageEffect>().PlayEffect();
        };
        //その他イベントの発火
        damageEvent.Invoke();
        //TODO:UnityEventで敵キャラの場合赤くしたりできる？
        //TODO:カウンター装備とか作れる？

        //体力の減少処理
        hp -= _damage;
        if(hp <= 0)
        {
            Dead();
        }
    }
    public void Dead()
    {
        //死亡処理
        gameObject.SetActive(false);
    }
}
