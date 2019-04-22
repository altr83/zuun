using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorialManager : MonoBehaviour {

    [HideInInspector]
    public bool tutorialCompleted = false;

    public string[] hints;
    public Text hintText;
    private int index = 0;

	void Update() {
        //hints = ["Hello username!", "This thing called crystalz","This thing help you to move faster",""];
        hintText.text = hints[index];
	}

	void OnCollisionEnter(Collision collision) {
		
	}
}
