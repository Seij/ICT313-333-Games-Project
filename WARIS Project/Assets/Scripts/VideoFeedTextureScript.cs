using UnityEngine;
using System.Collections;

public class VideoFeedTextureScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		Screen.sleepTimeout = SleepTimeout.NeverSleep;

		var deviceName = WebCamTexture.devices[0].name;
		
		var webCamTexture = new WebCamTexture(deviceName, 1280, 720, 30);
		
		webCamTexture.Play();
		
		
		renderer.material.mainTexture = webCamTexture;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
