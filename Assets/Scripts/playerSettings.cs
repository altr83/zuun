using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerSettings : MonoBehaviour
{
    [SerializeField]
    private Slider musicVolume, sfxVolume;

    [SerializeField]
    private Toggle povCamFlag, sideCamFlag;

    private void Awake() {
        initSettings();
        musicVolume.value = PlayerPrefs.GetFloat("musicVolume");
        sfxVolume.value = PlayerPrefs.GetFloat("sfxVolume");
    }

    private void Update() {
        if (PlayerPrefs.GetInt("povCamSet") == 1) {
            povCamFlag.isOn = true;
            sideCamFlag.isOn = false;
        }
        if (PlayerPrefs.GetInt("sideCamSet") == 1) {
            povCamFlag.isOn = false;
            sideCamFlag.isOn = true;
        }
    }

    public void musicVolumeSlider() {
        PlayerPrefs.SetFloat("musicVolume", musicVolume.value);
        PlayerPrefs.Save();
    }

    public void sfxVolumeSlider() {
        PlayerPrefs.SetFloat("sfxVolume", sfxVolume.value);
        PlayerPrefs.Save();
    }

    public void povCamSet() {
        int povValue = povCamFlag.isOn ? 1 : 0;
        PlayerPrefs.SetInt("povCamSet", povValue);
        PlayerPrefs.Save();
    }

    public void sideCamSet() {
        int sideValue = sideCamFlag.isOn ? 1 : 0;
        PlayerPrefs.SetInt("sideCamSet", sideValue);
        PlayerPrefs.Save();
    }

    private void initSettings() {
        if (!PlayerPrefs.HasKey("musicVolume")) {
            musicVolumeSlider();
        }

        if (!PlayerPrefs.HasKey("sfxVolume")) {
            sfxVolumeSlider();
        }

        if (!PlayerPrefs.HasKey("povCamSet")) {
            povCamSet();
        }

        if (!PlayerPrefs.HasKey("sideCamSet")) {
            sideCamSet();
        }
    }
}
