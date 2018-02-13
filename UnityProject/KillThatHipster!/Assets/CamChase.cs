using UnityEngine;
using System.Collections;

public class CamChase : MonoBehaviour {
	
	GameObject player;
	public float offsetX;
	public float offsetY;
	public float interStep;
	public float allowShakeDist;

	float lerpX;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
//		lerpX = Vector3.Lerp (transform.position, player.transform.position, interStep).x;
	}
	
	// Update is called once per frame
	void Update () {
//		Chase ();

		transform.position = new Vector3 (player.transform.position.x, transform.position.y, transform.position.z);

//		if (Mathf.Abs (transform.position.x - player.transform.position.x) < allowShakeDist) {
//			ScreenShake.allowShake = true;
//		} else {
//			ScreenShake.allowShake = false;
//		}
	}

	void LerpChase() {

		if (Mathf.Abs (transform.position.x - player.transform.position.x) > offsetX) {
			lerpX = Vector3.Lerp (transform.position, player.transform.position, interStep).x;
		}

		transform.position = new Vector3 (lerpX, transform.position.y, transform.position.z);

	}

	void Chase() {

		if (Mathf.Abs (transform.position.x - player.transform.position.x) > offsetX) {
			float dir = transform.position.x - player.transform.position.x > 0 ? -1 : 1;
			transform.position = new Vector3 (transform.position.x + interStep * dir, transform.position.y, transform.position.z);
		}
	}
}
