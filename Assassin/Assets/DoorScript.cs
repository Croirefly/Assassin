using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {


	public GameObject victoryWin;
	public Transform cam;
	
	private bool open = false;
	private bool win = false;
	public int unlockLevel;
	private Animator playerAnimator;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerStay2D(Collider2D other) {
		if (open == true) {
			if (other.gameObject.tag == "Player"){
				win = true;
				GameObject victoryInstance = Instantiate(victoryWin, cam.position + new Vector3 (0,0,20), cam.rotation) as GameObject;
				victoryInstance.transform.parent = cam;
				Destroy (gameObject);
				playerAnimator = other.GetComponent<Animator> ();
				playerAnimator.SetTrigger("Win");
				if(unlockLevel >= PlayerPrefs.GetInt ("Level")){
					PlayerPrefs.SetInt ("Level",unlockLevel); //unlock next level
				}
				open = false;
			}
		}
	}
	void KeyFull() {
		open = true;
		Debug.Log ("YOU WIN");
	}

}
