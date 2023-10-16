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
        sliderBGM.value = SoundManager.Insatance.bgmSource.volume;
        sliderSFX.value = SoundManager.Insatance.sfxSource.volume;
        sliderMaster.onValueChanged.AddListener(Set_MasterVolume);
        sliderBGM.onValueChanged.AddListener(Set_BGMVolume);
        sliderSFX.onValueChanged.AddListener(Set_SFXVolume);
    }

    private void Set_MasterVolume(float sliderVal)
    {
        SoundManager.Insatance.bgmSource.volume = sliderVal * sliderBGM.value;
        SoundManager.Insatance.sfxSource.volume = sliderVal * sliderSFX.value;

        SoundManager.Insatance.SfxPlay("Button");
    }

    private void Set_BGMVolume(float sliderVal)
    {
        SoundManager.Insatance.bgmSource.volume = sliderVal * sliderMaster.value;

        SoundManager.Insatance.SfxPlay("Button");
    }

    private void Set_SFXVolume(float sliderVal)
    {
        SoundManager.Insatance.sfxSource.volume = sliderVal * sliderMaster.value;

        SoundManager.Insatance.SfxPlay("Button");
    }


}
