using UnityEngine;
using System.Collections;

public class JulesMovement : MonoBehaviour {

	public float speed = 1;
	public float JumpForce = 1;
	public float JumpForceXAmplifier;

	public float raycastDistance = 200;
	bool isGrounded;
	Rigidbody2D rb;
	Animator anim;
	public LayerMask myLayerMask;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		isGrounded = checkGrounded();
		anim.SetBool ("isGround", isGrounded);

		float moveX = Input.GetAxisRaw ("Horizontal");

		Jump (moveX);
		Run (moveX);
		FlipX (moveX);
		

		//animations
		RunAnim(moveX);
		JumpAnim (rb.velocity.y);

		//debug
//		Debug.Log("VELOCITY Y: " + rb.velocity.y);

		//looking to various directions
		LookDirectionsAnim();


	
	}

	void Jump(float moveX) {

		if (Input.GetKeyDown (KeyCode.K) && isGrounded) {
			anim.SetTrigger ("Jump");
			rb.AddForce (new Vector2 (0f, JumpForce));
		}
			
	}

	void Run(float moveX){
		rb.velocity = new Vector2 (moveX * speed, rb.velocity.y);
	}

	void FlipX(float moveX) {

		if (moveX < 0) {
			transform.localScale = new Vector3 (-1, 1, 1);
		} else if (moveX > 0) {
			transform.localScale = new Vector3 (1, 1, 1);
		}
	}



	bool checkGrounded() {
		
		//set isGrounded to true, when hero is on ground

		RaycastHit2D rayhit = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance, myLayerMask);
		if (rayhit.collider != null && rayhit.collider.CompareTag ("Ground")) {
			return true;
		} else {
			return false;
		}

		
	}

	void RunAnim(float moveX) {
		if (moveX != 0) {
			anim.SetBool ("moveX", true);
		} else if (moveX == 0) {
			anim.SetBool ("moveX", false);
		}
	}

	void JumpAnim(float moveY) {
		anim.SetFloat ("velocityY", moveY);
	}

	void OnDrawGizmos() {

		Gizmos.color = Color.red;
		Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - raycastDistance));
	}

	void LookDirectionsAnim() {

		if (Input.GetKey (KeyCode.W)) {
			anim.SetBool ("Up", true);
		} else {
			anim.SetBool ("Up", false);
		}

		if (Input.GetKey (KeyCode.S)) {
			anim.SetBool ("Down", true);
		} else {
			anim.SetBool ("Down", false);
		}


	}
}
