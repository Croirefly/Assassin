using UnityEngine;
using System.Collections;

public class KeyHolderScriptLast : MonoBehaviour {

	private bool keyFull = false;
	public int keyHolderNumber = 1;
	public GameObject keyDisplay;
	public GameObject exit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame


	void KeyGet (GameObject other) {
		if(!keyFull){
			keyFull = true;
			GameObject keyDisplayInstance = Instantiate(keyDisplay, this.transform.position, this.transform.rotation) as GameObject;
			keyDisplayInstance.transform.parent = this.transform;
			exit.SendMessage ("KeyFull");
		}
	}
}
