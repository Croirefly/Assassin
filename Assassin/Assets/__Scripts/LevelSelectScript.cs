using UnityEngine;
using System.Collections;

public class LevelSelectScript : MonoBehaviour {

	public int levelNum;
	public GameObject bloodSlice;
	public float fadeInSpeed;
	public float fadeOutSpeed;

	private Transform player;
	private int unlockLevel;
	private SpriteRenderer renderer;
	private Animator playerAnimator;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player").transform;
		playerAnimator = player.GetComponent<Animator> ();

		unlockLevel = PlayerPrefs.GetInt ("Level");
		renderer = gameObject.GetComponent<SpriteRenderer> ();//Get the renderer via GetComponent or have it cached previously
		if(unlockLevel < levelNum) {
			renderer.color = new Color(255f, 255f, 255f, 0.4f);
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
	void HitByRay () {
		if(unlockLevel >= levelNum) {
		GameObject bloodSliceInstance = Instantiate
			(bloodSlice, this.transform.position - new Vector3(0,0,10), 
			 Quaternion.Euler(340, 90, 0)) as GameObject;
			player.position = new Vector2(this.transform.position.x, this.transform.position.y+0.1f);
			playerAnimator.SetTrigger("Slash");
			AutoFade.LoadLevel(levelNum, fadeInSpeed,fadeOutSpeed,Color.black);
			Destroy (gameObject);
		} else {
			playerAnimator.SetTrigger("Nope");
		}
	}
}
