using UnityEngine;
using System.Collections;

public class PlatformerCharacter2D : MonoBehaviour {

	protected Animator animator;
	private bool swordBlue = false;
	private bool swordGreen = false;
	private bool swordPurple = false;
	public GameObject auraBlue;
	public GameObject auraGreen;
	public GameObject auraPurple;
	public GameObject auraExplosion;
	private float x = 0f;

	void Start () {
		animator = GetComponent<Animator>();
	}
	
	void Update () {
		x -= 1;
		animator.SetFloat("Anim", x);

		if (Input.GetButtonDown("Fire1")){
			Debug.Log ("Left Clicked");
			Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y);
			RaycastHit2D hit = Physics2D.Raycast (mousePosition, Vector2.zero);
			if(hit.collider){
				if(hit.collider.tag == "Enemy"){
					Debug.Log ("We hit" + hit.collider.name);
					if (swordBlue) {
						hit.collider.BroadcastMessage ("HitByRay", "blue");
					} else if (swordGreen) {
						hit.collider.BroadcastMessage ("HitByRay", "green");
					} else if (swordPurple) {
						hit.collider.BroadcastMessage ("HitByRay", "purple");
					} else {
						hit.collider.BroadcastMessage ("HitByRay", "red");
					}
					
					x = 100f;
					animator.SetFloat("Anim",x);
				}

				if(swordBlue){
					if(hit.collider.tag == "Blue"){
						Debug.Log ("We hit" + hit.collider.name);
						hit.collider.SendMessage ("HitByBlue");
						x = 100f;
						animator.SetFloat("Anim",x);
					}
				}
				if(swordGreen){
					if(hit.collider.tag == "Green"){
						Debug.Log ("We hit" + hit.collider.name);
						hit.collider.SendMessage ("HitByGreen");
						x = 100f;
						animator.SetFloat("Anim",x);
					}
				}
				if(swordPurple){
					if(hit.collider.tag == "Purple"){
						Debug.Log ("We hit" + hit.collider.name);
						hit.collider.SendMessage ("HitByPurple");
						x = 100f;
						animator.SetFloat("Anim",x);
					}
				}
				if(hit.collider.tag == "Button"){
					Debug.Log ("We hit" + hit.collider.name);
					hit.collider.SendMessage ("HitByRay");
					x = 100f;
					animator.SetFloat("Anim",x);
				}
			}
		}

	}
	void OnCollisionEnter2D (Collision2D other) {
		if(other.gameObject.tag == "BlueSword"){
			DestroyAuras();
			GameObject auraBlueInstance = Instantiate(auraBlue, this.transform.position + new Vector3(0,0,1), this.transform.rotation) as GameObject;
			auraBlueInstance.transform.parent = this.transform;
			GameObject auraExplosionInstance = Instantiate(auraExplosion, this.transform.position + new Vector3(0,0,1), this.transform.rotation) as GameObject;
			swordGreen = false;
			swordPurple = false;
			swordBlue = true;
			Destroy(other.gameObject);
		}

		if(other.gameObject.tag == "GreenSword"){
			DestroyAuras();
			GameObject auraGreenInstance = Instantiate(auraGreen, this.transform.position + new Vector3(0,0,1), this.transform.rotation) as GameObject;
			auraGreenInstance.transform.parent = this.transform;
			GameObject auraExplosionInstance = Instantiate(auraExplosion, this.transform.position + new Vector3(0,0,1), this.transform.rotation) as GameObject;
			swordBlue = false;
			swordPurple = false;
			swordGreen = true;
			Destroy(other.gameObject);
		}
	
		if(other.gameObject.tag == "PurpleSword"){
			DestroyAuras();
			GameObject auraPurpleInstance = Instantiate(auraPurple, this.transform.position + new Vector3(0,0,1), this.transform.rotation) as GameObject;
			auraPurpleInstance.transform.parent = this.transform;
			swordBlue = false;
			swordGreen = false;
			swordPurple = true;
			Destroy(other.gameObject);
		}
	}

	void DestroyAuras () {
		Destroy (GameObject.FindGameObjectWithTag("BlueAura"));
		Destroy (GameObject.FindGameObjectWithTag("GreenAura"));
		Destroy (GameObject.FindGameObjectWithTag("PurpleAura"));
		GameObject auraExplosionInstance = Instantiate(auraExplosion, this.transform.position + new Vector3(0,0,1), this.transform.rotation) as GameObject;
	}
}
