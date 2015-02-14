using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeAttackController : MonoBehaviour {

	public Text timerText;
	public Text winText;
	public Text bestTimeText;
	public Text loseText;
	
	public Button replayButton;
	public Button resetButton;
	public float fadeInSpeed = 0.5f;
	public float fadeOutSpeed = 0.5f;

	private int count;
	private float minutes;
	private float seconds;
	private float milliseconds;

	private float bMinutes;
	private float bSeconds;
	private float bMilliseconds;
	private bool start = false;
	private bool win = false;
	private Transform player;

	// Use this for initialization
	void Awake () {
		replayButton.interactable = false; //deactivate buttons
		resetButton.interactable = false;
		player = GameObject.Find("Player").transform;
		//set best time
		bMinutes = PlayerPrefs.GetFloat ("bMinutes");
		bSeconds = PlayerPrefs.GetFloat ("bSeconds");
		bMilliseconds = PlayerPrefs.GetFloat ("bMilliseconds");
		if(bMilliseconds <= 10){
			bestTimeText.text = string.Format ("Best Time: " + "{0}:{1}:0{2}", bMinutes, bSeconds, (int)bMilliseconds);
			if(bSeconds <= 10) {
				bestTimeText.text = string.Format ("Best Time: " + "{0}:0{1}:0{2}", bMinutes, bSeconds, (int)bMilliseconds);
			}
		} else {
			bestTimeText.text = string.Format ("Best Time: " + "{0}:{1}:{2}", bMinutes, bSeconds, (int)bMilliseconds);
			if(bSeconds <= 10) {
				bestTimeText.text = string.Format ("Best Time: " + "{0}:0{1}:{2}", bMinutes, bSeconds, (int)bMilliseconds);
			}
		}
		
		bestTimeText.enabled = false;
	}
	
	// Update is called once per frame
	void FixedUpdate() {
		if(!start){
			if(player.position.y > -3){ //if player moves up, start = true
				start = true;
				Debug.Log("START");
			}
		}
		if(start){
			if(milliseconds >= 60){
				if(seconds >= 60){
					minutes++;
					seconds = 0;
				} else if(seconds <= 59){
					seconds++;
				}
				milliseconds = 0;
			}
			if(!win){
				milliseconds += Time.deltaTime * 100;
			}
			if(milliseconds <= 10){
				timerText.text = string.Format ("{0}:{1}:0{2}", minutes, seconds, (int)milliseconds);
				if(seconds <= 10) {
					timerText.text = string.Format ("{0}:0{1}:0{2}", minutes, seconds, (int)milliseconds);
				}
			} else {
				timerText.text = string.Format ("{0}:{1}:{2}", minutes, seconds, (int)milliseconds);
				if(seconds <= 10) {
					timerText.text = string.Format ("{0}:0{1}:{2}", minutes, seconds, (int)milliseconds);
				}
			}
		}
	}
	void Finish() {
		if(seconds >= 10 && seconds < 20){
			winText.text = "You Win!";
		} else if(seconds >= 20 && seconds < 30){
			winText.text = "You did aight.";
		} else if(seconds >=30){
			winText.text = "It's okay, I know you didn't try";
		}
		if (minutes+(seconds/60)+(milliseconds/6000) <= bMinutes+(bSeconds/60)+(bMilliseconds/6000)){
			PlayerPrefs.SetFloat ("bMinutes",minutes);
			PlayerPrefs.SetFloat ("bSeconds",seconds);
			PlayerPrefs.SetFloat ("bMilliseconds", milliseconds);
			bestTimeText.enabled = true;
			SetBestTime ();
			winText.text = "It's a NEW RECORD!";
		}


		win = true;
		replayButton.interactable = true; //activate buttons
		resetButton.interactable = true;

	}
	void SetBestTime() {

		bMinutes = PlayerPrefs.GetFloat ("bMinutes");
		bSeconds = PlayerPrefs.GetFloat ("bSeconds");
		bMilliseconds = PlayerPrefs.GetFloat ("bMilliseconds");
		if(bMilliseconds <= 10){
			bestTimeText.text = string.Format ("Best Time: " + "{0}:{1}:0{2}", bMinutes, bSeconds, (int)bMilliseconds);
			if(bSeconds <= 10) {
				bestTimeText.text = string.Format ("Best Time: " + "{0}:0{1}:0{2}", bMinutes, bSeconds, (int)bMilliseconds);
			}
		} else {
			bestTimeText.text = string.Format ("Best Time: " + "{0}:{1}:{2}", bMinutes, bSeconds, (int)bMilliseconds);
			if(bSeconds <= 10) {
				bestTimeText.text = string.Format ("Best Time: " + "{0}:0{1}:{2}", bMinutes, bSeconds, (int)bMilliseconds);
			}
		}
	}
	public void ResetBest() {
		PlayerPrefs.SetFloat ("bMinutes",99);
		PlayerPrefs.SetFloat ("bSeconds",99);
		PlayerPrefs.SetFloat ("bMilliseconds",99);
		SetBestTime ();
	}

	void BombHit() {
		loseText.text = string.Format ("Well you did click a bomb.");
		GameObject [] tEnemyArray = GameObject.FindGameObjectsWithTag ("Enemy"); //returns array of existing apples
		foreach ( GameObject tGO in tEnemyArray ) {
			Destroy  (tGO);
		}
		replayButton.interactable = true;
	}

	public void RestartLevel() {

		AutoFade.LoadLevel(Application.loadedLevel, fadeInSpeed,fadeOutSpeed, Color.black);
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			Finish();
		}
	}
}