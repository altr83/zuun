using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobileResolution : MonoBehaviour {

    public int x = 800, y = 450;
    public Camera cam;

	void Start () {
        Screen.SetResolution(x, y, true);
        cam.aspect = 16f / 9f;
	}
}
