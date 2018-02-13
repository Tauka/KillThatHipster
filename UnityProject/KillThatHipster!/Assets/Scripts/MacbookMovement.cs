using UnityEngine;
using System.Collections;

public class MacbookMovement : MonoBehaviour {

	GameObject player;
	public float speed;
	float directionX = 1;


	void Awake() {
		player = GameObject.FindGameObjectWithTag ("Hipster");
		directionX = player.transform.localScale.x;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = new Vector3 (transform.position.x + speed * Time.fixedDeltaTime * directionX, transform.position.y, transform.position.z);
	}
}
