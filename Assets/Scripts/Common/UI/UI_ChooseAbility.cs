using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ChooseAbility : MonoBehaviour
{
    bool isChoose = false;
    /// <summary>
    /// 受信した抽出アビリティリストをUIにセットする
    /// </summary>
    /// <param name="_abilityList"></param>
    public void SetUI(List<AbilityAsset> _abilityList)
    {
        //要素数分のアビリティアイコンを生成する
        //アビリティアイコンへ要素をセットする
    }
    public void SetAbility(AbilityAsset _abilityAsset)
    {
        //プレイヤーのアビリティをセットする
        if (isChoose) return;
        isChoose = true;
        //取得処理
        OverSceneData.instance.AbilityList.Add(_abilityAsset);
        EnhancementByAbility enhancementByAbility = GameObject.Find("EnhancementByAbility").GetComponent<EnhancementByAbility>();
        enhancementByAbility.Enhancement();
        //アビリティのウィンドウを非表示にする
    }
}
