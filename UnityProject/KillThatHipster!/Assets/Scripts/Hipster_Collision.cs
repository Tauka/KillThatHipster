using UnityEngine;
using System.Collections;

public class Hipster_Collision : MonoBehaviour {

	public GameObject hipster;


	// Use this for initialization
	void Start () {
		Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>(), this.gameObject.GetComponent<Collider2D>());
		Physics2D.IgnoreCollision(hipster.GetComponent<Collider2D>(), this.gameObject.GetComponent<Collider2D>());


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
