using UnityEngine;
using System.Collections;

public class ParticleSortingLayerScript : MonoBehaviour {

	public int orderNumber = 0;

	// Use this for initialization
	void Start () {
		particleSystem.renderer.sortingLayerName = "Effects";
		particleSystem.renderer.sortingOrder = orderNumber;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
