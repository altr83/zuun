using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Camera))]
public class VHSPostProcessEffect : MonoBehaviour {
	Material m;
	public Shader shader;

    #if UNITY_ANDROID || UNITY_IOS
         private string path = "/Assets/VHS/MovieTexture/glitch.mp4";
    #else
        public MovieTexture VHS;
    #endif

    float yScanline, xScanline;

    public void Start() {
		m = new Material(shader);


        #if UNITY_ANDROID || UNITY_IOS
            Handheld.PlayFullScreenMovie(path);
        #else
            m.SetTexture("_VHSTex", VHS);
            VHS.loop = true;
            VHS.Play();
        #endif
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination){
		yScanline += Time.deltaTime * 0.1f;
		xScanline -= Time.deltaTime * 0.1f;

		if(yScanline >= 1){
			yScanline = Random.value;
		}
		if(xScanline <= 0 || Random.value < 0.05){
			xScanline = Random.value;
		}
		m.SetFloat("_yScanline", yScanline);
		m.SetFloat("_xScanline", xScanline);
		Graphics.Blit(source, destination, m);
	}
}