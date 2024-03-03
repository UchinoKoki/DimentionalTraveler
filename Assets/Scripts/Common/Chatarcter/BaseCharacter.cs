using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using DG.Tweening;
using TMPro;
using UnityEngine.Events;

//参照サイト
//https://kingmo.jp/kumonos/unity-addressables-brief-summary/
public class BaseCharacter : MonoBehaviour
{
    public int hp;                      //体力
    [SerializeField] private UnityEvent damageEvent = new UnityEvent();    //ダメージを受けた時に呼び出すイベント
    private AsyncOperationHandle<GameObject> damageCanvas;    //ダメージエフェクトのプレハブ

    protected async void Start()
    {
        //ダメージエフェクトのプレハブを読み込む
        damageCanvas = Addressables.LoadAssetAsync<GameObject>("Assets/Prefabs/DamageCanvas.prefab");
    }

    //ダメージを受けたときのエフェクトまた計算処理
    public async void Damage(int _damage,GameObject _attacker)
    {
        if(hp <= 0)return;//既に死んでいたら処理しない

        //ダメージエフェクトの生成
        GameObject _loadedCanvas = await damageCanvas.Task;
        GameObject _instantiatedCanvas = Instantiate(_loadedCanvas,this.transform.position + new Vector3(0, 5, 0),Quaternion.identity);
        _instantiatedCanvas.transform.Find("DamageText").GetComponent<TextMeshProUGUI>().text = _damage.ToString();
        _instantiatedCanvas.GetComponent<DamageEffect>().PlayEffect();
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
