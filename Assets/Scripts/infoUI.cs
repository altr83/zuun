using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class infoUI : MonoBehaviour {

    public Text infoText;
    private string info;

	private void Update() {
        info = "Your speed is " + playerController.moveSpeed + "\n" + "Your package weight is " + playerScore.packageWeight;
        infoText.text = info;
	}
}
