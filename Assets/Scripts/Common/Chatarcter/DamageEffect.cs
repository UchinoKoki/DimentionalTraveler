using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class DamageEffect : MonoBehaviour
{
    private GameObject damageEffect;
    // Start is called before the first frame update
    void Start()
    {
        //ダメージエフェクトの生成
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayEffect()
    {

        Addressables.InstantiateAsync("Assets/Prefabs/DamageCanvas.prefab");
    }
}
