using UnityEngine;
using System.Collections;

public class CameraMouseDrag : MonoBehaviour {

	public GUISkin scrollbarSkin;
	private float vSbarValue;
	public float extraHeight;
	private Vector3 cameraPos;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {


	}
	void OnGUI() {
		if (extraHeight >= 1) {
			GUI.skin = scrollbarSkin;
			vSbarValue = GUI.VerticalScrollbar(new Rect(Screen.width/9-Screen.width/10, Screen.height/2-Screen.height/4, Screen.width/8-Screen.width/11, Screen.height/2), vSbarValue, 2.0F, extraHeight, 0.0F);
			cameraPos = new Vector3(0,vSbarValue,-25);
			camera.transform.position = cameraPos;
		}

	}
}
