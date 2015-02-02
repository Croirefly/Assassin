using UnityEngine;
using System.Collections;

public class LevelSelectControllerScript : MonoBehaviour {

	public int levelUnlock;
	public bool levelReset;
	public int levelResetNum = 1;

	// Use this for initialization
	void Awake () {
		if(levelReset){ //Resets level to a certain number for testing
			PlayerPrefs.SetInt ("Level",levelResetNum);
		}

		levelUnlock = PlayerPrefs.GetInt ("Level");
		if(levelUnlock <=1) {
			levelUnlock = 1;
			PlayerPrefs.SetInt ("Level",levelUnlock);
		}

		Debug.Log (levelUnlock);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
