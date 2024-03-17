using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVolume : MonoBehaviour
{
    [SerializeField] AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        
        foreach(AudioSource bgmAudioSource in audioManager.bgmAudioSourceList)
        {
            bgmAudioSource.volume = Mathf.Clamp(GameManager.instance.volumeList[0] * GameManager.instance.volumeList[1],0,1);

        }
        foreach(AudioSource seAudioSource in audioManager.seAudioSourceList)
        {
            seAudioSource.volume = Mathf.Clamp(GameManager.instance.volumeList[0] * GameManager.instance.volumeList[2],0,1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
