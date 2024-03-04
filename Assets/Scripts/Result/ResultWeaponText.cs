using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultWeaponText : MonoBehaviour
{
    [SerializeField]private List<TextMeshProUGUI> weaponTexts;

    void Start()
    {
        SetWeaponTexts();
    }
    
    void SetWeaponTexts()
    {
        for(int i = 0; i < weaponTexts.Count; i++)
        {
            string _weaponName = "None";
            if(OverSceneData.instance.WeaponList[i] == null) _weaponName = "None";
            else _weaponName = OverSceneData.instance.WeaponList[i].WeaponName; 
            weaponTexts[i].text = _weaponName;
        }
    }
}
