using UnityEngine;
using System.Collections;

public class Hipster1_AI : MonoBehaviour {

	public float moveSpeed;
	public float distanceToThrow;
	public float distanceToStopPunching;
	public float macbookCD;
	public float macbookDist;
	public float visibleY;
	public float hp;
	public float punchForce;
	public float punchDistance;
	public float distanceToPunch;
	public float punchStep;
	public float punchCooldown;

	public Transform[] somewheres;
	public Transform center;

	//checkDirBasedOnMovement() stuff
	bool oldM = false;
	bool newM = false;
	

	public GameObject macbook;

	Vector3 somewhere = Vector3.zero;
	ParticleSystem blood;
	float timer = 0;
//	float punchTimer = 0;
	float dir = 1;
	float secondfloor = 6;
	GameObject player;
	Animator anim;
	Rigidbody2D rb;


	void Awake() {
		anim = GetComponent<Animator> ();
		blood = GetComponent<ParticleSystem> ();
		rb = GetComponent<Rigidbody2D> ();
	}

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		somewhere = somewheres [Random.Range (0, somewheres.Length - 1)].position;
		dir = 1;
	}
	
	// Update is called once per frame
	void FixedUpdate () {



		//flip the sprite
		FlipX();

		//chases main player
		if (Mathf.Abs (player.transform.position.x - transform.position.x) > distanceToThrow && Mathf.Abs (player.transform.position.y - transform.position.y) < visibleY) {
			Chase ();

			anim.SetBool ("HipsterRun", true);
			anim.SetBool ("HipsterThrow", false);

			

		} else if (Mathf.Abs (player.transform.position.x - transform.position.x) < distanceToThrow && Mathf.Abs (player.transform.position.y - transform.position.y) < visibleY) {
			//animation
			anim.SetBool ("HipsterThrow", true);

			ThrowMacbook ();
			

		} else if (Mathf.Abs (player.transform.position.y - transform.position.y) > visibleY && transform.position.y > secondfloor) {
			GoToCenter ();
			anim.SetBool ("HipsterRun", true);
		} else if (Mathf.Abs (player.transform.position.y - transform.position.y) > visibleY && Mathf.Abs(transform.position.x - somewhere.x) > 0.1f) {
			GoToSomewhere();
			anim.SetBool ("HipsterRun", true);
		}
			else  {
			anim.SetBool ("HipsterThrow", false);
			anim.SetBool ("HipsterRun", false);

		}
	}

	void Chase() {

		dir = player.transform.position.x > transform.position.x ? 1 : -1;

		Move (dir);
	}

	void GoToSomewhere() {
		dir = transform.position.x - somewhere.x > 0 ? -1 : 1;
		transform.position = new Vector2 (transform.position.x + moveSpeed * dir * Time.fixedDeltaTime, transform.position.y);
	}

	void Move(float direction) {
		transform.position = new Vector2 (transform.position.x + moveSpeed * direction * Time.fixedDeltaTime, transform.position.y);

	}

	void GoToCenter() {

		dir = transform.position.x - center.position.x > 0 ? -1 : 1;
		transform.position = new Vector2 (transform.position.x + moveSpeed * dir * Time.fixedDeltaTime, transform.position.y);
	}

	void FlipX() {
		if (dir == 1) {
			transform.localScale = new Vector2 (1, 1);
		} else if (dir == -1) {
			transform.localScale = new Vector2 (-1, 1);
		}
	}
		

	void ThrowMacbook() {

		dir = player.transform.position.x > transform.position.x ? 1 : -1;

		if (Time.fixedTime > timer) {
			timer = Time.fixedTime + macbookCD;
			Instantiate (macbook, new Vector3 (transform.position.x + dir * macbookDist, transform.position.y, transform.position.z), Quaternion.identity);
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.CompareTag ("Bullet")) {
			ScreenShake.fire = true;
			GameController.score += 3;
			hpDown (StaticConstants.bulletDmg);

			//particle system (blood)
			blood.Play();

			if (hp <= 0) {
				
				GameController.score += 20;

				blood.startColor = Color.green;
				blood.startSpeed = 20;
				blood.Play ();
				Death ();
			}
		}
	}

	void Punch() {

		//animation
		anim.SetTrigger("Punch");

		//

	}

	void hpDown(float amount) {
		hp -= amount;
	}

	void Death () {
		Destroy (this.gameObject, 0.5f);
	}
		

}
