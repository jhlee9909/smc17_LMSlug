using UnityEngine;
using System.Collections;

public class ShooGun : MonoBehaviour {

	public GameObject GunArea;

	public GameObject Bullet;

	bool isAdvance;
	Vector2 Dir = new Vector2(1,0);
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Shoot ();
	}

	public void Shoot(){
	
		if(Input.GetKeyDown(KeyCode.LeftControl)){

			GameObject NowBullet = (GameObject)Instantiate (Bullet, GunArea.transform.position , Bullet.transform.rotation);
			NowBullet.transform.SetParent (GameObject.Find("PlayArea").transform);
			NowBullet.GetComponent<Rigidbody2D> ().AddForce (Dir*1000,ForceMode2D.Impulse);
				
			Debug.Log ("Shot");

		}
	
	}
	public void SetDir(bool GetisAdvance){
		isAdvance = GetisAdvance;
		if (isAdvance) {
			Dir = new Vector2 (1, 0);
		}
		if (!isAdvance) {
			Dir = new Vector2 (-1, 0);
		}
	}
}
