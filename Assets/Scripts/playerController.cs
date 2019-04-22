using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour {

	private float startSpeed;
	private Rigidbody rb;

    [HideInInspector]
	public static bool isMagent;
    [HideInInspector]
    public static float moveSpeed;

    [SerializeField]
    private GameObject povCam, sideCam;

	private void Start() {
		rb = GetComponent<Rigidbody>();
		isMagent = false;
        startSpeed = 101 - playerScore.packageWeight + 20;
	}

	private void FixedUpdate() {
        Movement();
        slowMotion();
        Magento();
    }

    private void Update() {
        moveSpeed = startSpeed + playerScore.scoreValue;
        //Invoke("Glitchez", 0.01f);
        if (PlayerPrefs.GetInt("povCamSet") == 1) {
            povCam.SetActive(true);
            sideCam.SetActive(false);
        }
        if (PlayerPrefs.GetInt("sideCamSet") == 1) {
            povCam.SetActive(false);
            sideCam.SetActive(true);
        }
    }

    private void Movement() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveUpDown = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(moveHorizontal, moveUpDown, 0f);
        transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        rb.AddForce(move * 25);
    }

    private void slowMotion() {
        if (Input.GetButtonDown("SlowMotion")) {
            Time.timeScale = 0.5f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
        else if (Input.GetButtonUp("SlowMotion")) {
            Time.timeScale = 1f;
            playerTiming t = new playerTiming();
            //t.nextLvl();
        }
    }

	private void Magento() {
		if (isMagent == true) {
            Invoke("turnOffMagnet", MagentObject.magentTime);
		}
	}

    private void turnOffMagnet() {
        isMagent = false;
    }

    private void Glitchez() {
        float _intervalOn = Random.Range(1, 10);
        Invoke("dsOn", _intervalOn);
        float _intervalOff = Random.Range(1, 10);
        Invoke("dsOff", _intervalOff);
    }

    private void dsOn() {
        Kino.Datamosh._sequence = 1;
    }

    private void dsOff() {
        Kino.Datamosh._sequence = 0;
    }



    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Border")) {
            soundEffects.playSound(soundEffects.border);
			playerScore.reloadScene();
            playerLifes.lostLife();
        }

        if (other.CompareTag("Finish")) {
			playerTiming.isStoped = true;
            Time.timeScale = 0;
        }
    }
}
