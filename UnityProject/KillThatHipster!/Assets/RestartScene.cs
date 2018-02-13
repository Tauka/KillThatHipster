using UnityEngine;
using System.Collections;

public class RestartScene : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Restart() {
		
		GameController.score = 0;
		GameController.difficulty = 0;
		Application.LoadLevel(Application.loadedLevel);
	}
}
