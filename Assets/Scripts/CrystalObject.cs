using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalObject : MonoBehaviour {

	
	public static int crystalValue = 1;

	private Transform target;
	private int moveSpeed = 300;
	private int rotationSpeed = 50;
	private int maxDistance = 1;
	private Transform crystalTransform;
    public bool isNotMagnetable;
	
	void Start() {
        isNotMagnetable = false;
		crystalTransform = this.transform;
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		target = player.transform;
	}

	void Update() {
        if (playerController.isMagent == true && isNotMagnetable == false) {
			Magnetable();
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Player")) {
            playerScore.scoreValue += crystalValue;
            soundEffects.playSound(soundEffects.crystal);
			Destroy(gameObject);
		}
	}

	private void Magnetable() {
		crystalTransform.rotation = Quaternion.Slerp(crystalTransform.rotation, Quaternion.LookRotation(target.position - crystalTransform.position), rotationSpeed * Time.deltaTime);
		if (Vector3.Distance(target.position, crystalTransform.position) > maxDistance) {
			crystalTransform.position += crystalTransform.forward * moveSpeed * Time.deltaTime;
		}
	}

}
