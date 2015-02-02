using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public GameObject bloodSlice;
	public GameObject bloodSliceBlue;
	public GameObject bloodSliceGreen;
	public GameObject bloodSlicePurple;
	
	public bool twoHit = false;
	public GameObject enemyOneHit;
	public bool threeHit = false;
	public GameObject enemyTwoHit;
	
	public int xWarp = 0;
	public int yWarp = 0;
	
	private Transform player;
	private Animator playerAnimator;
	private bool inRange = false;


	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player").transform;
		playerAnimator = player.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Range") {
			inRange = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Range") {
			inRange = false;
		}
	}
	
	void HitByRay(string color) {
		if(inRange) {

			if(color == "blue"){
				GameObject bloodSliceInstance = Instantiate
					(bloodSliceBlue, this.transform.position - new Vector3(0,0,10), 
					 Quaternion.Euler(340, 90, 0)) as GameObject;
			} else if(color == "green"){
				GameObject bloodSliceInstance = Instantiate
					(bloodSliceGreen, this.transform.position - new Vector3(0,0,10), 
					 Quaternion.Euler(340, 90, 0)) as GameObject;
			} else if(color == "purple"){
				GameObject bloodSliceInstance = Instantiate
					(bloodSlicePurple, this.transform.position - new Vector3(0,0,10), 
					 Quaternion.Euler(340, 90, 0)) as GameObject;
			} else if(color == "red"){
			GameObject bloodSliceInstance = Instantiate
				(bloodSlice, this.transform.position - new Vector3(0,0,10), 
				 Quaternion.Euler(340, 90, 0)) as GameObject;
			}

			if(twoHit){
				GameObject enemyOneHitInstance = Instantiate
					(enemyOneHit, this.transform.position + new Vector3 (xWarp, yWarp,0), this.transform.rotation) as GameObject;
			}
			if(threeHit){
				GameObject enemyTwoHitInstance = Instantiate
					(enemyTwoHit, this.transform.position + new Vector3 (xWarp, yWarp,0), this.transform.rotation) as GameObject;

			}
			player.position = new Vector2(this.transform.position.x + xWarp, this.transform.position.y+0.1f + yWarp);
			playerAnimator.SetTrigger("Slash");
			Destroy(gameObject);
		}
	}
	void HitByBlue() {
		if(inRange) {
			GameObject bloodSliceInstance = Instantiate
				(bloodSliceBlue, this.transform.position - new Vector3(0,0,10), 
				 Quaternion.Euler(340, 90, 0)) as GameObject;

			if(twoHit){
				GameObject enemyOneHitInstance = Instantiate
					(enemyOneHit, this.transform.position + new Vector3 (xWarp, yWarp,0), this.transform.rotation) as GameObject;
			}
			if(threeHit){
				GameObject enemyTwoHitInstance = Instantiate
					(enemyTwoHit, this.transform.position + new Vector3 (xWarp, yWarp,0), this.transform.rotation) as GameObject;
			}
			player.position = new Vector2(this.transform.position.x + xWarp, this.transform.position.y+0.1f + yWarp);
			playerAnimator.SetTrigger("Slash");
			Destroy(gameObject);
		}
	}
	void HitByGreen() {
		if(inRange) {
			GameObject bloodSliceInstance = Instantiate
				(bloodSliceGreen, this.transform.position - new Vector3(0,0,10), 
				 Quaternion.Euler(340, 90, 0)) as GameObject;

			if(twoHit){
				GameObject enemyOneHitInstance = Instantiate
					(enemyOneHit, this.transform.position + new Vector3 (xWarp, yWarp,0), this.transform.rotation) as GameObject;
			}
			if(threeHit){
				GameObject enemyTwoHitInstance = Instantiate
					(enemyTwoHit, this.transform.position + new Vector3 (xWarp, yWarp,0), this.transform.rotation) as GameObject;
			}
			player.position = new Vector2(this.transform.position.x + xWarp, this.transform.position.y+0.1f + yWarp);
			playerAnimator.SetTrigger("Slash");
			Destroy(gameObject);
		}
	}
	void HitByPurple() {
		if(inRange) {
			GameObject bloodSliceInstance = Instantiate
				(bloodSlicePurple, this.transform.position - new Vector3(0,0,10), 
				 Quaternion.Euler(340, 90, 0)) as GameObject;

			if(twoHit){
				GameObject enemyOneHitInstance = Instantiate
					(enemyOneHit, this.transform.position + new Vector3 (xWarp, yWarp,0), this.transform.rotation) as GameObject;
			}
			if(threeHit){
				GameObject enemyTwoHitInstance = Instantiate
					(enemyTwoHit, this.transform.position + new Vector3 (xWarp, yWarp,0), this.transform.rotation) as GameObject;
			}
			player.position = new Vector2(this.transform.position.x + xWarp, this.transform.position.y+0.1f + yWarp);
			playerAnimator.SetTrigger("Slash");
			Destroy(gameObject);
		}
	}
}
