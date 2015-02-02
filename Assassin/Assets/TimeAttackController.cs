using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeAttackController : MonoBehaviour {

	public Text timerText;
	public Text winText;
	public Text bestTimeText;
	
	public Button replayButton;
	public Button resetButton;
	private int count;
	private float minutes;
	private float seconds;
	private float milliseconds;
	
	private float bMinutes;
	private float bSeconds;
	private float bMilliseconds;
	private bool win = false;
	// Use this for initialization
	void Start () {
		replayButton.interactable = false;
		resetButton.interactable = false;
	}
	
	// Update is called once per frame
	void FixedUpdate() {
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
	void Finish() {
		winText.text = "You Win!";
		if (minutes+(seconds/60)+(milliseconds/6000) <= bMinutes+(bSeconds/60)+(bMilliseconds/6000)){
			PlayerPrefs.SetFloat ("bMinutes",minutes);
			PlayerPrefs.SetFloat ("bSeconds",seconds);
			PlayerPrefs.SetFloat ("bMilliseconds", milliseconds);
			SetBestTime ();
		}
		replayButton.interactable = true;
		resetButton.interactable = true;
		win = true;
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
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			Finish();
		}
	}
}