using UnityEngine;
using System.Collections;

public class PlayerMovement: MonoBehaviour {

	// Direction Vectors.
	private Vector3 moveDirection = Vector3.zero;
	private Vector3 rotateDirection = Vector3.zero;

	// Moving Speeds.
	public float moveSpeed = 7.0f;
	public float rotateSpeed = 180.0f;
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;

	// Choose to enable/disable side-walking.
	public bool sideWalk = true;

	// Button initial values. Possible values: (-1,0,1).
	private float verticalBtn = 0;
	private float horizontalBtn = 0;
	private float rotationBtn = 0;

	/** 
	 * Update is called once per frame.
	 */
	void Update () {
		// Read button and assign appropriate values.
		ButtonMapper ();
		// Call Player Movement.
		Movement ();
	}

	/** 
	 * Maps the buttons to float values.
	 */
	void ButtonMapper () {
		// Vertical Movement.
		if (Input.GetKey (KeyCode.UpArrow)) {
			verticalBtn = 1;
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			verticalBtn = -1;
		} else {
			verticalBtn = 0;
		}

		// Rotation Movement.
		if (Input.GetKey (KeyCode.RightArrow)) {
			rotationBtn = 1;
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			rotationBtn = -1;
		} else {
			rotationBtn = 0;
		}

		// Horizontal Movement(Side Walk).
		if (sideWalk) {
			if (Input.GetKey (KeyCode.D)) {
				horizontalBtn = 1;
			} else if (Input.GetKey (KeyCode.A)) {
				horizontalBtn = -1;
			} else {
				horizontalBtn = 0;
			}
		}
	}

	/*
	 * Movement Directions.
	*/
	void Movement () {
		CharacterController controller = GetComponent<CharacterController> ();

		// If the CharacterController is touching the ground, then enable it to move
		// and jump.
		if (controller.isGrounded) {
			// Apply direction values.
			moveDirection = new Vector3 (horizontalBtn, 0, verticalBtn);
			moveDirection = transform.TransformDirection (moveDirection);

			// Apply speeds.
			moveDirection *= moveSpeed;
			rotateDirection *= rotateSpeed;

			// Jump.
			if (Input.GetKey (KeyCode.Space)) {
				moveDirection.y = jumpSpeed;
			}
		} else {
			// If the CharacterController is on the air, then enable it to move.
			// Apply direction values.
			moveDirection = new Vector3 (horizontalBtn, moveDirection.y, verticalBtn);
			moveDirection = transform.TransformDirection (moveDirection);

			// Apply speeds.
			moveDirection.x *= moveSpeed;
			moveDirection.z *= moveSpeed;
		}

		// Apply rotation.
		rotateDirection = new Vector3 (0, rotationBtn, 0);
		rotateDirection *= rotateSpeed;

		// Apply Gravity.
		moveDirection.y -= gravity * Time.deltaTime;

		// Apply deltaTime.
		controller.Move (moveDirection * Time.deltaTime);
		transform.Rotate (rotateDirection * Time.deltaTime);
	}
}