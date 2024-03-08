using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AddressableAssets;

public class DamageEffect : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(Camera.main.transform);
    }
    public void PlayEffect()
    {
        this.transform.DOMove(this.transform.position + new Vector3(0, 5, 0) + new Vector3(0, 1, 0), 0.5f).OnComplete(() =>
        {
            Destroy(this.gameObject);
        });
    }
}
