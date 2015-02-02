using UnityEngine;
using System.Collections;

public class EnemyMultiHitScript : MonoBehaviour {

	
	public GameObject bloodSlice;
	public GameObject bloodSliceBlue;

	public bool twoHit = false;
	public GameObject enemyTwoHit;
	public bool threeHit = false;
	public GameObject enemyThreeHit;

	public int xWarp = 0;
	public int yWarp = 0;
	
	private Transform player;
	private bool inRange = false;


	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player").transform;
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
	
	void HitByRay() {
		if(inRange) {
			GameObject bloodSliceInstance = Instantiate
				(bloodSlice, this.transform.position - new Vector3(0,0,10), 
				 Quaternion.Euler(340, 90, 0)) as GameObject;
			if(twoHit){
				GameObject enemyTwoHitInstance = Instantiate
					(enemyTwoHit, this.transform.position + new Vector3 (xWarp, yWarp,0), this.transform.rotation) as GameObject;
			}
			if(threeHit){

			}
			player.position = new Vector2(this.transform.position.x + xWarp, this.transform.position.y+0.1f + yWarp);
			Destroy(gameObject);
		}
	}
	void HitByBlue() {
		if(inRange) {
			GameObject bloodSliceInstance = Instantiate
				(bloodSliceBlue, this.transform.position - new Vector3(0,0,10), 
				 Quaternion.Euler(340, 90, 0)) as GameObject;
			
			player.position = new Vector2(this.transform.position.x + xWarp, this.transform.position.y+0.1f + yWarp);
			Destroy(gameObject);
		}
	}
}
