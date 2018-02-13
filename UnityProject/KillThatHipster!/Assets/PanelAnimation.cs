using UnityEngine;
using System.Collections;

public class PanelAnimation : MonoBehaviour {

	Animator anim;
	public static bool panelHurt;

	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (panelHurt) {
			anim.SetTrigger ("panelHurt");
			panelHurt = false;
		}
	}
}
