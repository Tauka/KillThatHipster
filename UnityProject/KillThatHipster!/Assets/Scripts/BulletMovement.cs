using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

	public string objectTag;
	public float speed;
	GameObject player;
	float directionX = 1;
	float directionY = 0;
	JulesFire script;


	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag (objectTag);
		script = player.GetComponent<JulesFire> ();

	}

	void Start() {

		directionX = player.transform.localScale.x * script.direction.normalized.x;
		directionY = player.transform.localScale.y * script.direction.normalized.y;
		Vector2 trueDirection = new Vector2 (script.direction.x * player.transform.localScale.x, script.direction.y);

//		float angle = 0;


	



		transform.Rotate (Vector3.forward * dirAngle(trueDirection));


		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x + speed * Time.fixedDeltaTime * directionX, transform.position.y + speed * Time.fixedDeltaTime * directionY, transform.position.z);
		
	}

	float dirAngle(Vector2 direction) {
		if (direction.x == 1) {
			return 45 * direction.y;
		} else if (direction.x == -1) {
			return 180 - 45 * direction.y; 
		} else {
			return 90 * directionY;
		}
	}

		
}
