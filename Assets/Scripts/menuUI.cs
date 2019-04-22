using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuUI : MonoBehaviour {

    [SerializeField]
    private GameObject menuUIobj;

    [SerializeField]
    private GameObject aboutUIobj;

    [SerializeField]
    private GameObject settingsUIobj;

    [SerializeField]
    private GameObject delayedUIobj;

    void Awake() {
        delayTimer();
    }

    void FixedUpdate() {
        if (Input.GetButtonDown("Submit")) {
            delayedUIobj.SetActive(false);
            delayTimer();
        }
    }

    private void delayTimer() {
        Invoke("delayActive", 30f);
    }

    private void delayActive() {
        delayedUIobj.SetActive(true);
    }

    public void startButton() {
        SceneManager.LoadScene(1);
    }

    public void aboutButtonEnter() {
        menuUIobj.SetActive(false);
        aboutUIobj.SetActive(true);
    }

    public void aboutButtonExit() {
        aboutUIobj.SetActive(false);
        menuUIobj.SetActive(true);
    }

    public void settingsMenuEnter() {
        menuUIobj.SetActive(false);
        settingsUIobj.SetActive(true);
    }

    public void settingsMenuExit() {
        settingsUIobj.SetActive(false);
        menuUIobj.SetActive(true);
    }

    public void exitButton() {
        Application.Quit();
    }
}
