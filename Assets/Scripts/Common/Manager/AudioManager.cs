using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public List<AudioSource> bgmAudioSourceList = new List<AudioSource>();
    public List<AudioSource> seAudioSourceList = new List<AudioSource>();
    public List<Slider> volumeSliderList = new List<Slider>();
    [SerializeField] private GameObject audioPanel;
    // Start is called before the first frame update
    void Start()
    {
        foreach(AudioSource bgmAudioSource in bgmAudioSourceList)
        {
            bgmAudioSource.volume = Mathf.Clamp(GameManager.instance.volumeList[0] * GameManager.instance.volumeList[1],0,1);

        }
        foreach(AudioSource seAudioSource in seAudioSourceList)
        {
            seAudioSource.volume = Mathf.Clamp(GameManager.instance.volumeList[0] * GameManager.instance.volumeList[2],0,1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (audioPanel == null) return;
        if(!audioPanel.activeSelf) return;
        foreach(AudioSource bgmAudioSource in bgmAudioSourceList)
        {
            bgmAudioSource.volume = Mathf.Clamp(volumeSliderList[0].value * volumeSliderList[1].value,0,1);

        }
        foreach(AudioSource seAudioSource in seAudioSourceList)
        {
            seAudioSource.volume = Mathf.Clamp(volumeSliderList[0].value * volumeSliderList[2].value,0,1);
        }
        for(int i = 0; i < GameManager.instance.volumeList.Count; i++)
        {
            GameManager.instance.volumeList[i] = volumeSliderList[i].value;
        }
    }
}
