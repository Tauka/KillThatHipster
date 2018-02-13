using UnityEngine;
using System.Collections;

public class JulesPlatform : MonoBehaviour {

	Rigidbody2D rb;

	void Awake() {
		rb = GetComponent<Rigidbody2D> ();
	}
	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		Physics2D.IgnoreLayerCollision (LayerMask.NameToLayer("Ignore Raycast"), LayerMask.NameToLayer("Platform"), rb.velocity.y > 0);
	}
}
