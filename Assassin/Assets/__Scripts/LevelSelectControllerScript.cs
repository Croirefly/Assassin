using UnityEngine;
using System.Collections;

public class LevelSelectControllerScript : MonoBehaviour {

	public int levelUnlock;
	public bool levelReset;
	public int levelResetNum = 1;
	public Transform[] selectors;
	public Color[] colors;
	public float duration = 1f;

	public GameObject canvasCam;

	private Color oldColor;
	private Color newColor;
	private bool colorChange = false;
	private float deltaTime;
	private float camMoveY;
	private int colorNum;
	private int audioOn = 1;
	protected Animator audioAnim;
	private int musicOn = 1;
	protected Animator musicAnim;

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

		if (PlayerPrefs.HasKey("StartColor")){
			camMoveY = PlayerPrefs.GetFloat ("SelectPos");
			Camera.main.transform.position = new Vector3 (0, camMoveY,-25);
			WorldSelect (PlayerPrefs.GetInt ("StartColor"));
		} else {
			PlayerPrefs.SetInt ("StartColor",0);
		}
		if (PlayerPrefs.HasKey("audioOn")){//Check if audio has been turned off
			audioOn = PlayerPrefs.GetInt ("audioOn");
			if(audioOn == 0){ //1 == oN
				AudioToggle ();
			}
		} else {
			audioOn = 1;
		}
		if (PlayerPrefs.HasKey("musicOn")){//check is music has been turned off
			musicOn = PlayerPrefs.GetInt ("musicOn");
			if(audioOn == 0){ //1 == On
				MusicToggle ();
			}
		} else {
			musicOn = 1;
		}

		Debug.Log (levelUnlock);
	}
	
	// Update is called once per frame
	void Update () {
		if(colorChange){
			deltaTime += Time.deltaTime;
			if(deltaTime < duration){
				Camera.main.backgroundColor = Color.Lerp(oldColor, newColor, deltaTime/duration);
			} else {
				colorChange = false;
				PlayerPrefs.SetFloat ("SelectPos", this.transform.position.y);
			}
		}
		if(Camera.main.transform.position.y <= 0f){
			canvasCam.transform.position = new Vector3 (0, Camera.main.transform.position.y, 75);
		} else {
			canvasCam.transform.position = new Vector3 (0, 0, 75);
		}
	}

	public void WorldSelect (int worldNum) {
		this.transform.position = (selectors[worldNum].position - new Vector3 (-0.5f,0,25));
		oldColor = Camera.main.backgroundColor;
		newColor = colors[worldNum];
		deltaTime = 0;
		colorChange = true;
		PlayerPrefs.SetInt ("StartColor",worldNum);
	}

	public void AudioToggle () {
		GameObject audBut = GameObject.Find ("Audio_Button");
		if (audioOn == 1) {
			audioOn = 0;

		} else {
			audioOn = 1;
		}
		PlayerPrefs.SetInt ("audioOn",audioOn);
		audioAnim = audBut.GetComponent<Animator>();
		audioAnim.SetInteger("AudioOn",audioOn);

	}
	public void MusicToggle () {
		GameObject musicBut = GameObject.Find ("Music_Button");
		if (musicOn == 1) {
			musicOn = 0;
		} else {
			musicOn = 1;
		}
		PlayerPrefs.SetInt ("musicOn",musicOn);
		musicAnim = musicBut.GetComponent<Animator>();
		musicAnim.SetInteger("MusicOn",musicOn);
		//play sound
	}
}
