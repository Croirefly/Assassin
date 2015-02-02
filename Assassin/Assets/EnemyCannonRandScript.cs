using UnityEngine;
using System.Collections;

public class EnemyCannonRandScript : MonoBehaviour {

	public Rigidbody2D projectileLog;
	public Rigidbody2D projectileBomb;
	public float projVelocity = -2;
	public float interval = 1;
	public Transform spawn1;
	public Transform spawn2;
	public Transform spawn3;
	public Transform spawn4;


	private int bombChance;
	private int projChance;
	private Transform spawner;
	private Rigidbody2D projectile;

	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = new Vector2(0,20);
		InvokeRepeating ("LaunchProjectile", 0, interval); //time before starting, time interval
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	}
	// add if one column has it the others don't
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Finish"){
			Destroy(gameObject);
		}
	}

	void LaunchProjectile() {
		projChance = Random.Range (1,4);
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
	}
}
