using UnityEngine;
using System.Collections;

public class KeyHolderScript : MonoBehaviour {

	private bool keyFull = false;
	public int keyHolderNumber = 1;
	public GameObject keyDisplay;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame


	void KeyGet (GameObject other) {
		if(!keyFull){
			keyFull = true;
			GameObject keyDisplayInstance = Instantiate(keyDisplay, this.transform.position, this.transform.rotation) as GameObject;
			keyDisplayInstance.transform.parent = this.transform;
			
		} else {
			
			other.SendMessage ("KeyFull", keyHolderNumber);
		}
	}
}
