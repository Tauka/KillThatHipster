using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Transform[] spawnPoints;
	public Transform[] billPoints;
	public GameObject bill;
	public GameObject[] spawnElements;
	public float spawnCd;
	public Text scoreText;
	public Text finalScoreText;
	public Text levelText;
	public float difficultyCD;
	public float billCD;


	public static float difficulty = 1;

	float localSpawnCD;
	float localBillCD;

	public static float score = 0;
	float timer = 0;
	float difficultyTimer = 0;
	float billTimer = 0;


	// Use this for initialization
	void Start () {
		difficultyTimer += difficultyCD;
		localSpawnCD = spawnCd;
		localBillCD = billCD;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		Debug.Log ("HIPSTER CD: " + localSpawnCD);

		//set score
		scoreText.text = "Score: " + score;
		finalScoreText.text = "FINAL SCORE: " + score;
		levelText.text = "LEVEL: " + difficulty;
//		Debug.Log ("DIFFICULTY: " + difficulty);

		//spawn randomly
		if (Time.fixedTime > timer) {
			timer = Time.fixedTime + localSpawnCD;

			Spawn ();
		}

		//spawn Bills
		if (Time.fixedTime > billTimer) {
			billTimer = Time.fixedTime + localBillCD;
			Instantiate (bill, billPoints [Random.Range (0, billPoints.Length)].position, Quaternion.identity);
		}

		//increase difficulty
		if (Time.fixedTime > difficultyTimer && difficulty < 5) {
			difficultyTimer = Time.fixedTime + difficultyCD;
			difficulty = difficulty + 1;
			localSpawnCD = spawnCd / difficulty - 1f;
			localBillCD = billCD / difficulty - 2f;
		}


	}

	void Spawn() {

		Instantiate (spawnElements [Random.Range (0, spawnElements.Length)], spawnPoints [Random.Range (0, spawnPoints.Length)].position, Quaternion.identity);
//		Debug.Log(Random.Range(0, 3));

	}
}
