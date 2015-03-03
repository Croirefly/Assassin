using UnityEngine;
using System.Collections;

public class ClickButToLevelScript : MonoBehaviour {

	public string levelToLoad = "'Level01'";
	public float fadeInSpeed = 0.5f;
	public float fadeOutSpeed = 0.5f;

	// Use this for initialization
	public void LoadLevel () {
		
		AutoFade.LoadLevel(levelToLoad, fadeInSpeed,fadeOutSpeed,Color.black);
	}
}