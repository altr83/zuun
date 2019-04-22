using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombObject : MonoBehaviour {

	private static int damageValue = 2;

	private void OnTriggerEnter(Collider other) {
		if(other.CompareTag("Player")) {
            playerScore.scoreValue -= damageValue;
            soundEffects.playSound(soundEffects.damage);
			Destroy(gameObject);
		}
	}
}
