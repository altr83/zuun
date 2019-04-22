using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicRandom : MonoBehaviour {

    [SerializeField]
    private AudioSource[] audioObjects;

    private int index;
    private AudioSource currentMusicSource;

	private void Start () {
        randomizeAudio();
	}

    private void randomizeAudio() {
        index = Random.Range(0, audioObjects.Length);
        currentMusicSource = audioObjects[index];
        currentMusicSource.Play();
    }

    private void FixedUpdate() {
        currentMusicSource.volume = PlayerPrefs.GetFloat("musicVolume");
    }
}
