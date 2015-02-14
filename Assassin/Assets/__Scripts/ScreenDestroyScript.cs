using UnityEngine;
using System.Collections;

public class ScreenDestroyScript : MonoBehaviour {
	
	public float xRange = 23;
	public float yRange = 13;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x > xRange) {
			Destroy(gameObject);
		}
		else if(transform.position.x < -xRange){
			Destroy(gameObject);
		}
		if(transform.position.z > yRange) {
			Destroy(gameObject);
		}
		else if(transform.position.z < -yRange) {
			Destroy(gameObject);
		}
	}
}
