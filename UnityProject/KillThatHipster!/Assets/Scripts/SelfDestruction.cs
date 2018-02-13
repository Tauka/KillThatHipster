using UnityEngine;
using System.Collections;

public class SelfDestruction : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//TEMP: Destruction after 2sec
		Destroy (this.gameObject, 2f);
	}
}
