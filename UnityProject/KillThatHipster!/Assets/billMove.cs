using UnityEngine;
using System.Collections;

public class billMove : MonoBehaviour {

	GameObject player;
	public float speed;
	float direction = 1;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		direction = (player.transform.position.x - transform.position.x) > 0 ? 1 : -1;
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.position = new Vector3 (transform.position.x + speed * direction * Time.fixedDeltaTime, transform.position.y, transform.position.z);
		Destroy (this.gameObject, 3f);
	}


}
