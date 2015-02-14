using UnityEngine;
using System.Collections;

public class SelfDestructOnBeatScript : MonoBehaviour {
	
	float destructTimer;
	float bpm;
	
	// Use this for initialization
	void Start () {
		bpm = PlayerPrefs.GetInt ("BPM");
		destructTimer = (60/bpm);
		Destroy (gameObject, destructTimer);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
