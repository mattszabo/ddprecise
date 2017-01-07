using UnityEngine;
using System.Collections;

public class ImageViewer : MonoBehaviour {

	public string url = "http://www.google.com";

	IEnumerator Start() {
		WWW www = new WWW(url);
		yield return www;
		Renderer renderer = GetComponent<Renderer>();
		renderer.material.mainTexture = www.texture;
		Debug.Log ("www.texture");
		Debug.Log (www.texture);
	}

	public void OnClick() {
		Renderer renderer = GetComponent<Renderer>();
		Debug.Log(renderer.material.mainTexture);
	}
}
