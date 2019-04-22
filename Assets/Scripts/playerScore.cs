using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerScore : MonoBehaviour {

    [SerializeField]
    private Text scoreText;

    public static int scoreValue;
    public static int packageWeight;

    private void Awake() {
		scoreValue = 1;
        packageWeight = Random.Range(10,50);
    }

    private void Update() {
		updateScore();
        checkScore();
    }

    private void checkScore() {
        if (scoreValue <= 0) {
			reloadScene();
            playerLifes.lostLife();
        }
    }

	private void updateScore() {
		scoreText.text = scoreValue.ToString();
	}

    public static void reloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
