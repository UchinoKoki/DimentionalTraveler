using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fade;
using UnityEngine.Events;

public class GateProgress : MonoBehaviour
{
    //召喚スクリプト
    GatePopEnemy gatePopEnemy;

    //ゲートのチャージ
    [SerializeField] private float gateCharge;
    public float GateCharge { get { return gateCharge; } }

    //ゲートのチャージの最大値
    [SerializeField] private float gateChargeMax;
    [SerializeField] private float gateChargeSpeed;
    
    //ゲートの状態
    public bool isGateOpen = false;         //ゲートが開いているか(次のステージへ進むことができる状態か)
    public bool isGateCharging = false;     //ゲートがチャージしているか

    //パーティクル管理
    [SerializeField] private ParticleSystem outsideParticle;
    [SerializeField] private ParticleSystem insideParticle;

    //ゲートのチャージゲージ管理
    [SerializeField] private UI_GateGauge gateGauge;

    //その他イベント管理
    [SerializeField] private UnityEvent startChargeEvent;
    [SerializeField] private UnityEvent endChargeEvent;
    [SerializeField] private UnityEvent nextStageEvent;

    void Start()
    {
        //召喚スクリプトを取得
        gatePopEnemy = GetComponent<GatePopEnemy>();

        //パーティクルを停止
        outsideParticle.Stop();
        insideParticle.Stop();

        //ゲージを非表示
        gateGauge.gameObject.SetActive(false);
    }

    //チャージ
    public void Charge(bool _isCharge)
    {
        if(!isGateCharging) return;
        if(_isCharge)
        {
            if(gateCharge < gateChargeMax)
            {
                //チャージ処理
                gateCharge += gateChargeSpeed;
                gatePopEnemy.isOn = true;
                gateGauge.SetGauge(gateCharge / gateChargeMax);
            }
            else
            {
                //チャージ完了処理
                isGateOpen = true;
                gatePopEnemy.isOn = false;
                isGateCharging = false;
                outsideParticle.Stop();
                insideParticle.Stop();
                gateGauge.gameObject.SetActive(false);
                
                //その他イベントの発火
                endChargeEvent.Invoke();
            }
        }
        else
        {
            //チャージ範囲外処理
            if(gateCharge > 0)
            {
                //チャージの減衰
                //TODO:エリア外だとそもそもOnTriggerEnterが発火しないので減少してない
                gateCharge -= gateChargeSpeed * 0.8f;
            }
        }
    }

    //ゲートへのインタラクト
    public void Interact()
    {
        if(isGateOpen)
        {
            //イベント発火
            nextStageEvent.Invoke();
            //ゲートを通過する処理
            FadeManager.instance.FadeOut(Fade.FadeType.Normal);
            SceneManager.instance.LoadScene(ThisSceneState.instance.nextSceneName);
        }
        else if(!isGateCharging)
        {
            //ゲートをチャージする処理
            isGateCharging = true;
            outsideParticle.Play();
            insideParticle.Play();
            gateGauge.gameObject.SetActive(true);

            //その他イベントの発火
            startChargeEvent.Invoke();
        }
    }
}
