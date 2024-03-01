using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    int maxHP;
    int currentHP;
    [SerializeField] private Enemy enemy;
    [SerializeField] private BaseCharacter baseCharacter;
    // Start is called before the first frame update
    void Start()
    {
        maxHP = enemy.enemyAsset.hp;
        currentHP = baseCharacter.hp;
    }

    // Update is called once per frame
    void Update()
    {
        //カメラの方向を向く
        this.transform.rotation = Camera.main.transform.rotation;
        //HPバーの更新
        currentHP = baseCharacter.hp;
        slider.value = (float)currentHP / (float)maxHP;
    }
}
