using UnityEngine;
using System.Collections;

public class EnemyCannonScript : MonoBehaviour {

	public Rigidbody2D projectile;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("LaunchProjectile", 1, 3f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LaunchProjectile() {
		Rigidbody2D projectileInstance = (Rigidbody2D)Instantiate (projectile, this.transform.position, this.transform.rotation);
		projectileInstance.velocity = new Vector3(0,-2,0);
	}

}
