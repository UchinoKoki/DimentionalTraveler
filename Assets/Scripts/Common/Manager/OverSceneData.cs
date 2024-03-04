using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//シーン間でデータを短期的に保持するクラス
//統計のような使い方ではなく、１プレイに必要なデータ保持を目的とする
public class OverSceneData : MonoBehaviour
{
    //singleton
    public static OverSceneData instance;

    //プレイヤーのアビリティを保持
    public List<AbilityAsset> AbilityList = new List<AbilityAsset>();
    public int AbilityCost;

    //プレイヤーの装備を保持
    public List<WeaponAsset> WeaponList = new List<WeaponAsset>();

    //ステージ数を保持
    public int stageNum;

    //現在の時間を保存する
    public float nowTime;
    public bool isTimeCount{private get; set;} = false;


    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
