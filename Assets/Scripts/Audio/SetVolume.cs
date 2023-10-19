using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    [SerializeField] private Slider sliderMaster;
    [SerializeField] private Slider sliderBGM;
    [SerializeField] private Slider sliderSFX;

    private void Start()
    {
        sliderMaster.value = SoundManager.Insatance.masterVolume;
        sliderBGM.value = SoundManager.Insatance.bgmVolume;
        sliderSFX.value = SoundManager.Insatance.sfxVolume;
        sliderMaster.onValueChanged.AddListener(Set_MasterVolume);
        sliderBGM.onValueChanged.AddListener(Set_BGMVolume);
        sliderSFX.onValueChanged.AddListener(Set_SFXVolume);
    }

    private void Set_MasterVolume(float sliderVal)
    {
        SoundManager.Insatance.masterVolume = sliderVal;
        SoundManager.Insatance.bgmSource.volume = sliderVal * sliderBGM.value;
        SoundManager.Insatance.sfxSource.volume = sliderVal * sliderSFX.value;

        SoundManager.Insatance.SfxPlay("Button");
    }

    private void Set_BGMVolume(float sliderVal)
    {
        SoundManager.Insatance.bgmVolume = sliderVal;
        SoundManager.Insatance.bgmSource.volume = sliderVal * sliderMaster.value;

        SoundManager.Insatance.SfxPlay("Button");
    }

    private void Set_SFXVolume(float sliderVal)
    {
        SoundManager.Insatance.sfxVolume = sliderVal;
        SoundManager.Insatance.sfxSource.volume = sliderVal * sliderMaster.value;

        SoundManager.Insatance.SfxPlay("Button");
    }


}
