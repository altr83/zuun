using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class graphicSettings : MonoBehaviour
{
    [SerializeField]
    private GameObject povCam, sideCam;

    [SerializeField]
    private Toggle glitchsToggle, vhsToggle, grayscaleToggle, tubeToggle;

    private void Awake() {
        initGraphicSettings();
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("povCamSet") == 1) {
            settingsControl(povCam);
        }

        if (PlayerPrefs.GetInt("sideCamSet") == 1) {
            settingsControl(sideCam);
        }
    }

    private void initGraphicSettings() {
        if (!PlayerPrefs.HasKey("glitchs")) {
            glitchSet();
        }

        if (!PlayerPrefs.HasKey("vhs")) {
            vhsSet();
        }

        if (!PlayerPrefs.HasKey("grayscale")) {
            grayscaleSet();
        }

        if (!PlayerPrefs.HasKey("tube")) {
            tubeSet();
        }
    }

    public void glitchSet() {
        int glitchsValue = glitchsToggle.isOn ? 1 : 0;
        PlayerPrefs.SetInt("glitchs", glitchsValue);
        PlayerPrefs.Save();
    }

    public void vhsSet() {
        int vhsValue = vhsToggle.isOn ? 1 : 0;
        PlayerPrefs.SetInt("vhs", vhsValue);
        PlayerPrefs.Save();
    }

    public void grayscaleSet() {
        int grayscaleValue = grayscaleToggle.isOn ? 1 : 0;
        PlayerPrefs.SetInt("grayscale", grayscaleValue);
        PlayerPrefs.Save();
    }

    public void tubeSet() {
        int tubeValue = tubeToggle.isOn ? 1 : 0;
        PlayerPrefs.SetInt("tube", tubeValue);
        PlayerPrefs.Save();
    }

    private void settingsControl(GameObject camera) {
        if (PlayerPrefs.GetInt("glitchs") == 1) {
            camera.GetComponent<GlitchEffect>().enabled = true;
        } else {
            camera.GetComponent<GlitchEffect>().enabled = false;
            glitchsToggle.isOn = false;
        }

        if (PlayerPrefs.GetInt("vhs") == 1) {
            camera.GetComponent<VHSPostProcessEffect>().enabled = true;
        } else {
            camera.GetComponent<VHSPostProcessEffect>().enabled = false;
            vhsToggle.isOn = false;
        }

        if (PlayerPrefs.GetInt("grayscale") == 1) {
            camera.GetComponent<UnityStandardAssets.ImageEffects.Grayscale>().enabled = true;
        } else {
            camera.GetComponent<UnityStandardAssets.ImageEffects.Grayscale>().enabled = false;
            grayscaleToggle.isOn = false;
        }

        if (PlayerPrefs.GetInt("tube") == 1) {
            camera.GetComponent<Kino.Tube>().enabled = true;
        } else {
            camera.GetComponent<Kino.Tube>().enabled = false;
            tubeToggle.isOn = false;
        }
    }
}
