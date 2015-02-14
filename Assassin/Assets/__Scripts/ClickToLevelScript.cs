using UnityEngine;
using System.Collections;

public class ClickToLevelScript : MonoBehaviour {

	public string levelToLoad = "'Level01'";
	public float fadeInSpeed = 0.5f;
	public float fadeOutSpeed = 0.5f;
	public GameObject bloodSlice;

	private Transform player;
	private Animator playerAnimator;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player").transform;
		playerAnimator = player.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void HitByRay() {
		GameObject bloodSliceInstance = Instantiate
			(bloodSlice, this.transform.position - new Vector3(0,0,10), 
			 Quaternion.Euler(340, 90, 0)) as GameObject;
		player.position = new Vector2(this.transform.position.x, this.transform.position.y+0.1f);
		playerAnimator.SetTrigger("Slash");
		Destroy(gameObject);
		Debug.Log ("BUTTON CLICKED");
		AutoFade.LoadLevel(levelToLoad, fadeInSpeed,fadeOutSpeed,Color.black);

	}
}
