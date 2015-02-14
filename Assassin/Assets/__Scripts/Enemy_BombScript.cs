using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Enemy_BombScript : MonoBehaviour {

	private GameObject gameController;
	public GameObject bombExplosion;

	// Use this for initialization
	void Awake() {

	}
	void HitByRay(string color) {
		gameController = GameObject.Find("Finish Box Controller");
		gameController.SendMessage("BombHit");
		GameObject bombExplosionInstance = Instantiate (bombExplosion, this.transform.position, this.transform.rotation) as GameObject; 
	}
}
