using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;

    void Start(){

        GameObject screenObject = GameObject.Find("ScreenSettings");
        GameObject volumeObject = GameObject.Find("VolumeSettings");
        GameObject textObject = GameObject.Find("TextSettings");

        screenObject.SetActive(true);
        volumeObject.SetActive(false);
        textObject.SetActive(false);

    }

    public void SetMusicVolume(float volume){

        audioMixer.SetFloat("musicVolume", Mathf.Log10(volume) * 20);

    }

    public void SetSoundsVolume(float volume){

        audioMixer.SetFloat("soundsVolume", Mathf.Log10(volume) * 20);

    }
    
    public void SetQuality(int index){

        QualitySettings.SetQualityLevel(index);

    }

    public void SetFullscreen(bool isFullscreen){

        Screen.fullScreen = isFullscreen;

    }

}
