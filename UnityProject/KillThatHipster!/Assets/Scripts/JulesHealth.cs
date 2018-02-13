using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class JulesHealth : MonoBehaviour {

	public float hp;

	public Image[] hearts;

	int heartsCount;

	float pseudoHp = 0;
	float baseHp;
	SpriteRenderer sprite;
	bool hurt = false;

	AudioSource hurtAudio;

	public GameObject endScreen;

	void Awake() {
		sprite = GetComponent<SpriteRenderer> ();
		hurtAudio = GetComponents<AudioSource> () [1];
		heartsCount = hearts.Length;
		pseudoHp = hp / 10;
		baseHp = hp / 10;
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (hurt) {
			sprite.color = Color.red; 
			hurt = false;
		} else {
			sprite.color = Color.white;
		}
//		sprite.color = Color.white; 
	}

	void hpDown(float amount) {
		//play hurt sound
		hurtAudio.Play();
		hp -= amount;
		pseudoHp -= amount;
	}

	void hpUp(float amount) {
		hp += amount;
		pseudoHp += amount % ((hp / 10) + 1);
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.CompareTag("Macbook")) {
			hurt = true;
			hpDown (StaticConstants.macbookDmg);

			//hurt indication
//			sprite.color = Color.red; 

			if (hp <= 0) {
				Death ();
				endScreen.SetActive (true);
			}

			if (pseudoHp <= 0) {
				
				noHeart ();
				Debug.Log (hp);
				pseudoHp = baseHp;
				PanelAnimation.panelHurt = true;
			}
		} else if (collider.CompareTag("Bill")) {
			hurt = true;
			hp = 0;

			//hurt indication
			//			sprite.color = Color.red; 

			if (hp <= 0) {
				Death ();
				endScreen.SetActive (true);
			}

			for (int i = 0; i < 10; i++) {
				noHeart ();
			}
		}
	}

	void noHeart() {
		if (heartsCount > 0) {
			Destroy (hearts [heartsCount - 1].gameObject);
			heartsCount--;
		}
	}

	void Death () {
		Destroy (this.gameObject);
	}
}
