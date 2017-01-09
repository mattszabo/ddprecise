using UnityEngine;
using System.Collections;

public class WebPageViewer : MonoBehaviour {

	public string url = "http://www.google.com";

	IEnumerator Start() {
		WWW www = new WWW(url);
		yield return www;
		Renderer renderer = GetComponent<Renderer>();
		renderer.material.mainTexture = www.texture;
	}
		
}
