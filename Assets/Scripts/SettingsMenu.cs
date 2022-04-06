using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public Slider VolumeSlider;
    public float Volume;

    [Header("Graphics")]
    public GameObject LowGraphics;
    public GameObject MediumGraphics;
    public GameObject HighGraphics;

    [Header("Effects")]
    public GameObject EffectsOn;
    public GameObject EffectsOff;
    public AudioSource EffectsSource;

    [Header("Music")]
    public GameObject MusicOn;
    public GameObject MusicOff;
    public AudioSource MusicSource;

    public AudioMixer mixer;

    // Start is called before the first frame update
    void Start()
    {
        // MasterVolume
        if (PlayerPrefs.HasKey("musicVolume") == false)
        {
            PlayerPrefs.SetFloat("musicVolume", 1f);
        }
        else
            PlayerPrefs.GetFloat("musicVolume");

        Volume = PlayerPrefs.GetFloat("musicVolume", 0.75f);
        VolumeSlider.value = Volume;

        //Graphics
        GraphicsLoad();

        // Music
        MusicLoad();

        // Effects
        EffectsLoad();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MusicEnable()
    {
        PlayerPrefs.SetInt("Music", 1);
        MusicSource.Play();
        MusicOff.SetActive(false);
        MusicOn.SetActive(true);
    }

    public void MusicDisable()
    {
        PlayerPrefs.SetInt("Music", 0);
        MusicSource.Stop();
        MusicOn.SetActive(false);
        MusicOff.SetActive(true);
    }

    public void EffectsEnable()
    {
        PlayerPrefs.SetInt("Effects", 1);
        EffectsSource.Play();
        EffectsOff.SetActive(false);
        EffectsOn.SetActive(true);
    }

    public void EffectsDisable()
    {
        PlayerPrefs.SetInt("Effects", 0);
        EffectsSource.Stop();
        EffectsOn.SetActive(false);
        EffectsOff.SetActive(true);
    }

    public void Low()
    {
        QualitySettings.SetQualityLevel(0);
        LowGraphics.SetActive(true);
        MediumGraphics.SetActive(false);
        HighGraphics.SetActive(false);
    }

    public void Medium()
    {
        QualitySettings.SetQualityLevel(1);
        LowGraphics.SetActive(false);
        MediumGraphics.SetActive(true);
        HighGraphics.SetActive(false);
    }

    public void High()
    {
        QualitySettings.SetQualityLevel(3);
        LowGraphics.SetActive(false);
        MediumGraphics.SetActive(false);
        HighGraphics.SetActive(true);
    }

    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("MasterVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MasterVolume", sliderValue);
    }

    // Load Variables For Start
    public void GraphicsLoad()
    {
        if (PlayerPrefs.HasKey("Graphics") == false)
        {
            PlayerPrefs.SetInt("Graphics", 2);
        }
        else
            PlayerPrefs.GetInt("Graphics");

        if (PlayerPrefs.GetInt("Graphics") == 1)
        {
            QualitySettings.SetQualityLevel(0);
            LowGraphics.SetActive(true);
            MediumGraphics.SetActive(false);
            HighGraphics.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Graphics") == 2)
        {
            QualitySettings.SetQualityLevel(1);
            LowGraphics.SetActive(false);
            MediumGraphics.SetActive(true);
            HighGraphics.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Graphics") == 2)
        {
            QualitySettings.SetQualityLevel(3);
            LowGraphics.SetActive(false);
            MediumGraphics.SetActive(false);
            HighGraphics.SetActive(true);
        }
    }

    public void MusicLoad()
    {
        if (PlayerPrefs.HasKey("Music") == false)
        {
            PlayerPrefs.SetInt("Music", 1);
        }
        else
            PlayerPrefs.GetInt("Music");

        if (PlayerPrefs.GetInt("Music") == 1)
        {
            MusicSource.Play();
            MusicOff.SetActive(false);
            MusicOn.SetActive(true);
        }
        else
        {
            MusicSource.Stop();
            MusicOn.SetActive(false);
            MusicOff.SetActive(true);
        }
    }

    public void EffectsLoad()
    {
        if (PlayerPrefs.HasKey("Effects") == false)
        {
            PlayerPrefs.SetInt("Effects", 1);
        }
        else
            PlayerPrefs.GetInt("Effects");

        if (PlayerPrefs.GetInt("Effects") == 1)
        {
            EffectsSource.Play();
            EffectsOff.SetActive(false);
            EffectsOn.SetActive(true);
        }
        else
        {
            EffectsSource.Stop();
            EffectsOn.SetActive(false);
            EffectsOff.SetActive(true);
        }
    }
}
