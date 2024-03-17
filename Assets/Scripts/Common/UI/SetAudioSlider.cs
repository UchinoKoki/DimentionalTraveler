using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAudioSlider : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;

    void Start()
    {
        audioManager.volumeSliderList[0].value = GameManager.instance.volumeList[0];
        audioManager.volumeSliderList[1].value = GameManager.instance.volumeList[1];
        audioManager.volumeSliderList[2].value = GameManager.instance.volumeList[2];
    }
}
