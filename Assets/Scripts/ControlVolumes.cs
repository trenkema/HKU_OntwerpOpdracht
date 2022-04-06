using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlVolumes : MonoBehaviour
{
    [Header("Music Volume")]
    [Range(0.0001f, 1.0f)]
    [SerializeField]
    float musicVolume = 1.0f;
    public Slider musicVolumeSlider;
    public AudioSource musicSource;

    [Header("SoundFX Volume")]
    [Range(0.0001f, 1.0f)]
    [SerializeField]
    float soundFxVolume = 1.0f;
    public Slider soundFxVolumeSlider;
    public AudioSource soundFxSource;

    // Start is called before the first frame update
    void Start()
    {
        // Music Volume
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            musicVolume = PlayerPrefs.GetFloat("musicVolume", 0.5f);
            musicVolumeSlider.value = musicVolume;
        }
        else
        {
            PlayerPrefs.SetFloat("musicVolume", 0.5f);
            musicVolume = PlayerPrefs.GetFloat("musicVolume", 0.5f);
            musicVolumeSlider.value = musicVolume;
        }

        musicSource.volume = musicVolume;

        // Sound Fx Volume
        if (PlayerPrefs.HasKey("soundFxVolume"))
        {
            soundFxVolume = PlayerPrefs.GetFloat("soundFxVolume", 0.5f);
            soundFxVolumeSlider.value = soundFxVolume;
        }
        else
        {
            PlayerPrefs.SetFloat("soundFxVolume", 0.5f);
            soundFxVolume = PlayerPrefs.GetFloat("soundFxVolume", 0.5f);
            soundFxVolumeSlider.value = soundFxVolume;
        }

        soundFxSource.volume = soundFxVolume;
    }

    public void ChangeMusicVolume()
    {
        musicVolume = musicVolumeSlider.value;
        musicSource.volume = musicVolume;
        PlayerPrefs.SetFloat("musicVolume", musicVolume);
    }

    public void ChangeSoundFxVolume()
    {
        soundFxVolume = soundFxVolumeSlider.value;
        soundFxSource.volume = soundFxVolume;
        PlayerPrefs.SetFloat("soundFxVolume", soundFxVolume);
    }
}
