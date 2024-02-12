using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepAbilityData : MonoBehaviour
{
    public AbilityAsset Ability;

    //UIを使う場合は登録させる
    void Start()
    {
        if(transform.parent.gameObject.GetComponent<AbilityUI>())transform.parent.gameObject.GetComponent<AbilityUI>().SetUIList(this);
    }
}
