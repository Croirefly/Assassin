using UnityEngine;
using System.Collections;

public class EnemyCannonRandScript : MonoBehaviour {

	public Rigidbody2D projectileLog;
	public Rigidbody2D projectileBomb;
	public float projVelocity = -2;
	public Transform spawn1;
	public Transform spawn2;
	public Transform spawn3;
	public Transform spawn4;


	private int bombChance;
	private int projChance;
	private int oldChance;
	private Transform spawner;
	private Rigidbody2D projectile;
	private int randOneTwo;
	private float distance;

	// Use this for initialization
	void Start () {
		distance = 0;
		GetComponent<Rigidbody2D>().velocity = new Vector2(0,45);
		//InvokeRepeating ("LaunchProjectile", 0.3f, interval); //time before starting, time interval
		oldChance = 1;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(distance > 3){
			LaunchProjectile();
			distance = 0;
		}
		distance = distance + 1;
	}
	// add if one column has it the others don't
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Finish"){
			Destroy(gameObject);
		}
	}

	void LaunchProjectile() {
		projChance = Random.Range (1,5);
		//Debug.Log (projChance + " - " + oldChance+ " = "+ Mathf.Abs(projChance - oldChance));
		randOneTwo = Random.Range (1,3);
		if (Mathf.Abs(projChance - oldChance) == 3){
			Random.Range (1,4);
			if(projChance == 4) {
				projChance = projChance - randOneTwo;
			}
			if(projChance == 1) {
				projChance = projChance + randOneTwo;
			}
		}
		//Debug.Log ("Double gap because: " + projChance);

		if(projChance == 1){
			Rigidbody2D projectileInstance = (Rigidbody2D)Instantiate (projectileLog, spawn1.position, this.transform.rotation);
		} else {
			Rigidbody2D projectileInstance = (Rigidbody2D)Instantiate (projectileBomb, spawn1.position, this.transform.rotation);
		}
		if(projChance == 2){
			Rigidbody2D projectileInstance = (Rigidbody2D)Instantiate (projectileLog, spawn2.position, this.transform.rotation);
		} else {
			Rigidbody2D projectileInstance = (Rigidbody2D)Instantiate (projectileBomb, spawn2.position, this.transform.rotation);
		}
		if(projChance == 3){
			Rigidbody2D projectileInstance = (Rigidbody2D)Instantiate (projectileLog, spawn3.position, this.transform.rotation);
		} else {
			Rigidbody2D projectileInstance = (Rigidbody2D)Instantiate (projectileBomb, spawn3.position, this.transform.rotation);
		}
		if(projChance == 4){
			Rigidbody2D projectileInstance = (Rigidbody2D)Instantiate (projectileLog, spawn4.position, this.transform.rotation);
		} else {
			Rigidbody2D projectileInstance = (Rigidbody2D)Instantiate (projectileBomb, spawn4.position, this.transform.rotation);

		}
		oldChance = projChance;
	}
}
