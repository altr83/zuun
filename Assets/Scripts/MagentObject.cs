using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagentObject : MonoBehaviour {

    public static float magentTime;
    public float tmp;

	void Start() {
        magentTime = tmp;
	}

	private void OnTriggerEnter(Collider other) {
		if(other.CompareTag("Player")) {
            playerController.isMagent = true;
            soundEffects.playSound(soundEffects.magent);
			Destroy(gameObject);
		}
	}
}
