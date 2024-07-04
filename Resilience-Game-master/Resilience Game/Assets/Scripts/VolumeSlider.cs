using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    //store audio mixer and sliders for changing volume
    [SerializeField]
    AudioMixer audioMixer;
    [SerializeField]
    Slider musicVolume;

    public void SetMusicVolume(float volume)
    {
        //set the music volume using slider value
        audioMixer.SetFloat("volume", volume);
    }

    private void Start()
    {
        //get the value of audio mixer and set slider value when loading new scene
        float mixerVolume;
        audioMixer.GetFloat("volume", out mixerVolume);
        musicVolume.value = mixerVolume;
    }
}
