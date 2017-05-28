using UnityEngine;
using System.Collections;

public class CharCameraController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("Char").transform.position.x > 0 && gameObject.transform.position.x >= 0) {
			gameObject.transform.position = new Vector3 (GameObject.Find ("Char").transform.position.x, 0, 0);
		}
		if (gameObject.transform.position.x < 0) {
			Debug.Log ("OutOfCam");
			gameObject.transform.position.Set(0,0,0);
		}
	}
}
