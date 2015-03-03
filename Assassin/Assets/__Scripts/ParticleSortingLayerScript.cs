using UnityEngine;
using System.Collections;

public class ParticleSortingLayerScript : MonoBehaviour {

	public int orderNumber = 0;

	// Use this for initialization
	void Start () {
		GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = "Effects";
		GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingOrder = orderNumber;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
