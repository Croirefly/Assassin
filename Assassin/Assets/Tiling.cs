using UnityEngine;
using System.Collections;

[RequireComponent (typeof(SpriteRenderer))]

public class Tiling : MonoBehaviour {

	public int offsetY = 2;			// the offset so that we don't get any weird errors

	// these are used for checking if we need to instantiate stuff
	public bool hasATopBuddy = false;
	public bool hasABotBuddy = false;

	public bool reverseScale = false;	// used if the object is not tilable

	private float spriteHeight = 0f;		// the height of our element
	private Camera cam;
	private Transform myTransform;

	void Awake () {
		cam = Camera.main;
		myTransform = transform;
	}

	// Use this for initialization
	void Start () {
		SpriteRenderer sRenderer = GetComponent<SpriteRenderer>();
		spriteHeight = sRenderer.sprite.bounds.size.y;
	}
	
	// Update is called once per frame
	void Update () {
		// does it still need buddies? If not do nothing
		if (hasABotBuddy == false || hasATopBuddy == false) {
			// calculate the cameras extend (half the width) of what the camera can see in world coordinates
			float camVerticalExtend = cam.orthographicSize * Screen.height/Screen.width;

			// calculate the x position where the camera can see the edge of the sprite (element)
			float edgeVisiblePositionTop = (myTransform.position.y + spriteHeight/2) - camVerticalExtend;
			float edgeVisiblePositionBot = (myTransform.position.y - spriteHeight/2) + camVerticalExtend;

			// checking if we can see the edge of the element and then calling MakeNewBuddy if we can
			if (cam.transform.position.y >= edgeVisiblePositionTop - offsetY && hasATopBuddy == false)
			{
				MakeNewBuddy (1);
				hasATopBuddy = true;
			}
			else if (cam.transform.position.y <= edgeVisiblePositionBot + offsetY && hasABotBuddy == false)
			{
				MakeNewBuddy (-1);
				hasABotBuddy = true;
			}
		}
	}

	// a function that creates a buddy on the side required
	void MakeNewBuddy (int topOrBot) {
		// calculating the new position for our new buddy
		Vector3 newPosition = new Vector3 (myTransform.position.x, myTransform.position.y + spriteHeight * topOrBot, myTransform.position.z);
		// instantating our new body and storing him in a variable
		Transform newBuddy = Instantiate (myTransform, newPosition, myTransform.rotation) as Transform;

		// if not tilable let's reverse the x size og our object to get rid of ugly seams
		if (reverseScale == true) {
			newBuddy.localScale = new Vector3 (newBuddy.localScale.x, newBuddy.localScale.y * -1, newBuddy.localScale.z);
		}

		newBuddy.parent = myTransform.parent;
		if (topOrBot > 0) {
			newBuddy.GetComponent<Tiling>().hasABotBuddy = true;
		}
		else {
			newBuddy.GetComponent<Tiling>().hasATopBuddy = true;
		}
	}
}
