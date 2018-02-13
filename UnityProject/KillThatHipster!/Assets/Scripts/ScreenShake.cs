using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour
{

	Camera cam;
	public float maxScreenShakeAmount;
	public float rate;
	public float duration;
	public static bool fire;
	public static bool allowShake;


	Vector3 startPos;

	void Awake ()
	{
		cam = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ();
	}

	// Use this for initialization
	void Start ()
	{
		startPos = cam.transform.position;

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (fire) {
			Invoke ("CamShake", 0f);
			Invoke ("StopShake", duration);
			fire = false;
		}
	}

	void CamShake ()
	{
		//screen shake
		float shake = Random.Range (-1.0f, 1.0f) * maxScreenShakeAmount; 
		cam.transform.position = new Vector3 (cam.transform.position.x + shake, cam.transform.position.y, cam.transform.position.z);
	}

	void StopShake ()
	{
		CancelInvoke ("CamShake");
		cam.transform.position = startPos;
	}

}
