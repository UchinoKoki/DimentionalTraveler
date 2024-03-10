using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityItem : MonoBehaviour
{
    [SerializeField] private AbilityListAsset abilityListAsset;//アビリティアイテムのリスト
    private List<AbilityAsset> sentAbilityList;//プレイヤーへ提示するアビリティリスト
    private UI_ChooseAbility ui_ChooseAbility;//アビリティのウィンドウ

    /// <summary>
    /// アビリティアイテムを取得する
    /// </summary>
    /// <param name="_pickNum"></param>
    /// <param name="player"></param>
    public void GetAbilityItem(int _pickNum,Player player)
    {
        //アビリティのウィンドウを取得する
        ui_ChooseAbility = GameObject.Find("ChooseAbilityWindow").GetComponent<UI_ChooseAbility>();
        //アビリティUIへアビリティを送信する
        AccessGetAbilityUI(3,player);
    }
    
    /// <summary>
    /// アビリティのウィンドウへアビリティを送信する
    /// </summary>
    /// <param name="_pickNum">プレイヤーへ提示する要素数</param>
    /// <param name="player">取得するプレイヤー</param>
    /// <returns>プレイヤーが選択したアビリティ</returns>
    private void AccessGetAbilityUI(int _pickNum,Player player)
    {
        //アビリティのウィンドウから選択されたアビリティを取得する
        sentAbilityList = SetList(_pickNum,sentAbilityList);
        //アビリティのウィンドウへアビリティを送信する
        SetUI(sentAbilityList);
    } 

    /// <summary>
    /// アビリティリストをセットする
    /// </summary>
    /// <param name="_pickNum">プレイヤーへ提示する要素数</param>
    /// <param name="_list">アビリティリスト</param>
    /// <returns>プレイヤーへ提示するアビリティリスト</returns>
    private List<AbilityAsset> SetList(int _pickNum ,List<AbilityAsset> _list)
    {
        if(_list.Count != 0) return _list;//アビリティリストに要素が既に入っている場合は処理をしない

        var _pickAbilityList = new List<AbilityAsset>();//return用のリスト
        for(; _list.Count > _pickNum;)
        {
            //アビリティのリストからランダムにピックアップする
            int _pickAbility = Random.Range(0, abilityListAsset.abilityList.Count);

            //重複していないか確認する
            if(!_pickAbilityList.Contains(abilityListAsset.abilityList[_pickAbility]))
            {
                //重複しなかったときの処理
                _pickAbilityList.Add(abilityListAsset.abilityList[_pickAbility]);
            }
        }

        return _pickAbilityList;
    }
    private void SetUI(List<AbilityAsset> _abilityList)
    {
        ui_ChooseAbility.SetUI(_abilityList);
    }
}
