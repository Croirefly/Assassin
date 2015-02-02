using UnityEngine;
using System.Collections;

public class EnemyWalkingScript : MonoBehaviour {

	public Vector2 pointB;
	public float speed = 3.0f;
	public float waitTime = 1.0f;

	// Use this for initialization
	IEnumerator Start () {
		var pointA = transform.position;
		while(true)
		{
			yield return StartCoroutine(MoveObject(transform, pointA, pointB, speed, waitTime));
			yield return StartCoroutine(MoveObject(transform, pointB, pointA, speed, waitTime));
		}
	}
	
	// Update is called once per frame
	IEnumerator MoveObject(Transform thisTransform, Vector2 startPos, Vector2 endPos, float time, float waitTime)
	{
		var i= 0.0f;
		var rate= 1.0f/time;
		while(i < 1.0f)
		{
			i += Time.deltaTime * rate;
			thisTransform.position = Vector3.Lerp(startPos, endPos, i);
			yield return null;
		}
		yield return new WaitForSeconds(waitTime);
	}
}
