using UnityEngine;
using System.Collections;

public class KeyScript : MonoBehaviour {

	public Transform player;
	public GameObject keyHolderOne;
	public GameObject keyHolderTwo;
	public GameObject keyHolderThree;
	private bool inRange;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Range") {
			inRange = true;
		}
		if(other.gameObject.tag == "Player"){
			Destroy(gameObject);
			keyHolderOne.SendMessage ("KeyGet", this.gameObject);
		}
	}
	
	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Range") {
			inRange = false;
		}
	}
	
	void HitByRay(string color) {
		if(inRange) {
			Destroy(gameObject);
			keyHolderOne.SendMessage ("KeyGet", this.gameObject);
		}
	}

	void KeyFull (int holdNumber) {
		if(holdNumber == 1){
			keyHolderTwo.SendMessage ("KeyGet", this.gameObject);
		}
		if(holdNumber == 2){
			keyHolderThree.SendMessage ("KeyGet", this.gameObject);
		}
	}


}
