using UnityEngine;
using System.Collections;

public class LevelSelectControllerScript : MonoBehaviour {

	public int levelUnlock;
	public bool levelReset;
	public int levelResetNum = 1;
	public Transform[] selectors;
	public Color[] colors;
	public float duration = 1f;

	private Color oldColor;
	private Color newColor;
	private bool colorChange = false;
	private float deltaTime;

	// Use this for initialization
	void Awake () {
		if(levelReset){ //Resets level to a certain number for testing
			PlayerPrefs.SetInt ("Level",levelResetNum);
		}

		levelUnlock = PlayerPrefs.GetInt ("Level");
		if(levelUnlock <=1) {
			levelUnlock = 1;
			PlayerPrefs.SetInt ("Level",levelUnlock);
		}

		Debug.Log (levelUnlock);
	}
	
	// Update is called once per frame
	void Update () {
		if(colorChange){
			deltaTime += Time.deltaTime;
			if(deltaTime < duration){
				Camera.main.backgroundColor = Color.Lerp(oldColor, newColor, deltaTime);
			} else {
				colorChange = false;
			}
		}
	}

	public void WorldSelect (int worldNum) {
		this.transform.position = (selectors[worldNum].position - new Vector3 (-0.5f,0,25));
		oldColor = Camera.main.backgroundColor;
		newColor = colors[worldNum];
		deltaTime = 0;
		colorChange = true;
	}
}
