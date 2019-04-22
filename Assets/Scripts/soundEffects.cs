using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundEffects : MonoBehaviour {

    public AudioSource crystalSound, damageSound, magentSound, borderSound;
    public static AudioSource crystal, damage, magent, border;

    private void Awake() {
        crystal = crystalSound;
        damage = damageSound;
        magent = magentSound;
        border = borderSound;

        setVolume();
	}

    public static void playSound(AudioSource sound) {
        sound.Play();
    }

    private void setVolume() {
        crystalSound.volume = PlayerPrefs.GetFloat("sfxVolume");
        damageSound.volume = PlayerPrefs.GetFloat("sfxVolume");
        magentSound.volume = PlayerPrefs.GetFloat("sfxVolume");
        borderSound.volume = PlayerPrefs.GetFloat("sfxVolume");
    }
}
