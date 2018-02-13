using UnityEngine;
using System.Collections;

public class JulesFire : MonoBehaviour {

	public float Offset;
	public float fireCooldown;
	public GameObject bullet;
	

	Animator anim;
	AnimatorStateInfo currentAnim;
	AudioSource fireAudio;
	float fireRate = 0;
	public Vector2 direction = Vector2.zero;

	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator> ();
		fireAudio = GetComponents<AudioSource> ()[0];
	}

	void Start() {
		
	}
	
	// Update is called once per frame
	void Update () {

		currentAnim = anim.GetCurrentAnimatorStateInfo (0);
		
		Debug.Log ("JULES DOWN " + Animator.StringToHash ("JulesDown"));
		

		//change direction depending on animation
		if (currentAnim.IsName("JulesDown")) {
			direction = Vector2.down;
		} else if (currentAnim.IsName("JulesUp")) {
			direction = Vector2.up;
		} else if (currentAnim.IsName("JulesDownForward")) {
			direction = new Vector2 (1, -1);
		} else if (currentAnim.IsName("JulesUpForward")) {
			direction = new Vector2 (1, 1);
		} else  {
			direction = new Vector2 (1, 0);
		}

		Fire ();
	}
	
	void Fire() {
		if (Input.GetKey (KeyCode.J) && Time.fixedTime > fireRate) {
			fireRate = Time.fixedTime + fireCooldown;
			float x = transform.position.x + Offset * transform.localScale.x * direction.normalized.x;
			float y = transform.position.y + Offset * direction.normalized.y;

			//play sound
			fireAudio.Play();
			
			Instantiate (bullet, new Vector3 (x, y, transform.position.z), Quaternion.identity);
		} else {
			
		}
	}
}
