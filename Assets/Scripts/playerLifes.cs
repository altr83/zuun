using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerLifes : MonoBehaviour {

    public static int lifes = 4;
    private static bool isCreated = false;

    [SerializeField]
    private Text lifesText;

    [SerializeField]
    private GameObject zeroLifes;

	private void Awake() {
        if(!isCreated) {
            DontDestroyOnLoad(this.gameObject);
            isCreated = true;
        }

        lifesText.text = lifes.ToString();
	}
	
    private void Update() {
        if(lifes == 0) {
            Time.timeScale = 0;
            zeroLifes.SetActive(true);
        }
	}

    public static void lostLife() {
        lifes--;
    }
}
