using UnityEngine;
using System.Collections;

public class GPSCompassTest : MonoBehaviour {
	// Use this for initialization
	void Start () {
		Input.location.Start ();
		Input.compass.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler(0, -Input.compass.trueHeading, 0);
	}
}