using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerTiming : MonoBehaviour {

	public Text timerText;
    public Text resultText;
	public GameObject resultObjct;
    public GameObject settingsMenu;
	private float startTime = 0f;
	public static string tempTimeValue;
	public static bool isStoped = false;
	private bool isPaused = false;

    [SerializeField]
    private Text totalPlayerScore;

    private void Awake() {
        if (!PlayerPrefs.HasKey("totalPlayerScore")) {
            PlayerPrefs.SetInt("totalPlayerScore", 0);
            PlayerPrefs.Save();
        }
    }

    private void Update() {
		if (isStoped == false) {
			startTime += Time.deltaTime * 10;
		} else {
			tempTimeValue = startTime.ToString();
		}
		updatingTime(startTime);
    }

	private void updatingTime(float timeInSeconds) {

        string formatedTime = timeInSeconds.ToString();

        if (isStoped == false) {
			timerText.text = formatedTime;
        }
        else {
			resultObjct.SetActive(true);
			int formTime = (int)startTime;
            int value = formTime/playerScore.packageWeight;
			resultText.text = value.ToString();
            int currentTotalScore = PlayerPrefs.GetInt("totalPlayerScore");
            PlayerPrefs.SetInt("totalPlayerScore", currentTotalScore + value);
            PlayerPrefs.Save();
        }
    }

	public void nextLvl() {

        /*
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = Random.Range(1, 3);

        if (nextScene == currentScene) {
            nextScene = Random.Range(1, 3);
            isStoped = false;
        }

        SceneManager.LoadScene(nextScene); 
        */

        isStoped = false;
        SceneManager.LoadScene(1);
	}


    public void lastlvl() {
        SceneManager.LoadScene(1);
        isStoped = false;
    }

    public void fired() {
        SceneManager.LoadScene(0);
        playerLifes.lifes = 4;
    }

	public void gamePause() {
		isPaused = !isPaused;

		if (isPaused == true) {
			Time.timeScale = 0;
            settingsMenu.SetActive(true);
		} else {
			Time.timeScale = 1;
            settingsMenu.SetActive(false);
        }
	}
}
