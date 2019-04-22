using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hintUI : MonoBehaviour {

    [SerializeField]
    private string[] hints;

    [SerializeField]
    private Text hintText;
    private int index;

	private void Start() {
        randomizeHints();
	}

    private void randomizeHints() {
        index = Random.Range(0, hints.Length);
        hintText.text = hints[index];
    }
}
