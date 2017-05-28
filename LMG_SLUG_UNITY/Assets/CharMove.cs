using UnityEngine;
using System.Collections;

public class CharMove : MonoBehaviour {
	
	public float speed=650f;
	bool isJump;

	Component charSprite;
	bool isAdvance;

	GameObject testHand;
	public GameObject CharHand;

	// Use this for initialization
	void Start () {

//		check GameObject have child and child have sprite
		if (gameObject.transform.childCount > 0 && gameObject.GetComponentInChildren<SpriteRenderer> ()) {
			charSprite = gameObject.transform.GetChild(0);
		}

//		testHand = transform.Find ("Char/Gun").gameObject;
//
//		if(testHand)
//		Debug.Log ("yyy");

	}
	
	// Update is called once per frame
	void Update () {
		InputKeyMove ();
		SetSpriteDir ();
	}


	public void InputKeyMove(){
		if (Input.anyKeyDown) {

			gameObject.transform.GetChild (0).GetComponent<Animator> ().SetBool ("isWalk", true);

		}

		if(Input.GetKeyDown (KeyCode.UpArrow)){
			//this.transform.Translate (Vector3.forward*3.0f*Time.deltaTime); 
			Jump();
		}
//		if(Input.GetKey (KeyCode.DownArrow)){
//			this.transform.Translate (Vector3.forward*3.0f*Time.deltaTime); }
		if(Input.GetKey (KeyCode.LeftArrow)){
			isAdvance = false;
			this.transform.Translate (Vector2.left*speed*Time.deltaTime); }
		if(Input.GetKey (KeyCode.RightArrow)){
			isAdvance = true;
			this.transform.Translate (Vector2.right*speed*Time.deltaTime); }



		if (!Input.anyKey && !Input.anyKeyDown) {
			gameObject.transform.GetChild (0).GetComponent<Animator> ().SetBool ("isWalk", false);
		} 

	}

	public void SetSpriteDir(){
	
		charSprite.gameObject.GetComponent<SpriteRenderer> ().flipX = isAdvance;
		gameObject.SendMessage ("SetDir", isAdvance);
		SetCharHandDir ();
	}
	public void SetCharHandDir(){

//		if (isAdvance) {
//			CharHand.GetComponent<RectTransform> ().rotation = Quaternion.Euler (0, 180, 0);
//		}
//		else if (!isAdvance) {
//			CharHand.GetComponent<RectTransform> ().rotation = Quaternion.Euler (0, 0, 0);
//		}

	}
	public void Jump(){
		if (isJump) {
			return;
		}
		gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 100 * 5, ForceMode2D.Impulse);
		Debug.Log ("Jump");
	}
	public void isOnGround(){



	}
	public void OnCollisionStay2D(Collision2D col){

		isJump = false;

	}
	public void OnCollisionExit2D(Collision2D col){

		isJump = true;

	}


}
