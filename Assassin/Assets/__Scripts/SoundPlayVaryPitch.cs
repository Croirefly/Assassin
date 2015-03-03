using UnityEngine;
using System.Collections;

public class SoundPlayVaryPitch : MonoBehaviour {

	public float pitchMax = 1;
	public float pitchMin = 1;

	private float pitchSound;
	private int pitchVar;


	// Use this for initialization
	void Start () {
		pitchVar = Random.Range(1,4);
		Debug.Log (pitchVar);
		if (pitchVar == 1){
			pitchSound = pitchMax;
		}
		if (pitchVar == 2){
			pitchSound = 1.0f;
		}
		if (pitchVar == 3){
			pitchSound = pitchMin;
		}

		GetComponent<AudioSource>().pitch = pitchSound;
		GetComponent<AudioSource>().Play ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
