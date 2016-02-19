using UnityEngine;
using System.Collections;

public class PlayerMovement: MonoBehaviour {

	public float moveSpeed = 5.0f;
	public float rotateSpeed = 180.0f;
	public bool sideWalk = true;

	
	/*
	 * Update is called once per frame
	*/
	void Update () {
		// Call Player Movement.
		Movement ();
	}


	/*     
	 * Movement Directions.
	*/
	void Movement () {
		// Horizontal Movement (Forwards and Backwards).
		if (Input.GetKey (KeyCode.UpArrow)) {
			Debug.Log ("Key UpArrow Pressed.");
			this.transform.Translate (new Vector3 (0, 0, moveSpeed * Time.deltaTime)); 
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			Debug.Log ("Key DownArrow Pressed.");
			this.transform.Translate (new Vector3 (0, 0, -moveSpeed * Time.deltaTime)); 
		} 
			
		// Horizontal Movement (Rotate).
		if (Input.GetKey (KeyCode.RightArrow)) {
			Debug.Log ("Key RightArrow Pressed.");
			this.transform.Rotate (new Vector3 (0, rotateSpeed * Time.deltaTime, 0)); 
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			Debug.Log ("Key LeftArrow Pressed.");
			this.transform.Rotate (new Vector3 (0, -rotateSpeed * Time.deltaTime, 0)); 
		}

		// Horizontal (Side Walk).
		if (sideWalk) {
			if (Input.GetKey (KeyCode.D)) {
				// D: Go right.
				Debug.Log ("Key D Pressed.");
				this.transform.Translate (new Vector3 (moveSpeed * Time.deltaTime, 0, 0));
			} else if (Input.GetKey (KeyCode.A)) {
				// A: Go left.
				Debug.Log ("Key A Pressed.");
				this.transform.Translate (new Vector3 (-moveSpeed * Time.deltaTime, 0, 0));
			}
		}

		// Vertical Movement (Float Up and Down).
		if (Input.GetKey (KeyCode.W)) {
			// W: Go up.
			Debug.Log ("Key W Pressed.");
			this.transform.Translate (new Vector3 (0, moveSpeed * Time.deltaTime, 0));
		} else if (Input.GetKey (KeyCode.S)) {
			// S: Go down.
			Debug.Log ("Key S Pressed.");
			this.transform.Translate (new Vector3 (0, -moveSpeed * Time.deltaTime, 0));
		}
	}
}
