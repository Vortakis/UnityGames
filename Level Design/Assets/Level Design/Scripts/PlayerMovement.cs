﻿using UnityEngine;
using System.Collections;

public class PlayerMovement: MonoBehaviour {

	/* CharacterState Enum indicates current state of player. */
	public enum CharacterState {
		Idle = 0,
		Walking = 1,
		Jumping = 2,
		WalkingOnAir = 3
	}

	/* CharacterController variable. */
	private CharacterController controller;

	/* CharacterState variable, to store the current state. */
	public CharacterState characterState = CharacterState.WalkingOnAir;

	/* Direction Variables. */
	private Vector3 moveDirection = Vector3.zero;
	private Vector3 rotateDirection = Vector3.zero;

	/* Applied forces and speeds. */
	public float moveSpeed = 7.0f;
	public float rotateSpeed = 180.0f;
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;

	/* sideWalk: Choose to enable/disable side-walking. */
	public bool sideWalk = true;

	/* Movement buttons initial values. Possible values: (-1,0,1). */
	private float verticalBtn = 0;
	private float horizontalBtn = 0;
	private float rotationBtn = 0;

	public string standingOn = null;

	/** 
	 * Update is called once per frame.
	 */
	void Update () {
		// Get CharacterController.
		controller = GetComponent<CharacterController> ();

		// Idle State: No force is applied, and player is sitting idle on the ground.
		if (controller.isGrounded) {
			characterState = CharacterState.Idle;
		}

		// Input Mapper and assign appropriate values for movement.
		ButtonMapper ();

		// Allow Player Movement.
		Movement ();

		// Allow Player Moving on a slope.
		MoveOnSteepSlope ();

		// Apply movement.
		controller.Move (moveDirection * Time.deltaTime);
	}

	void OnControllerColliderHit (ControllerColliderHit hit) {
		standingOn = hit.collider.name;
	}

	/** 
	 * Maps the buttons to float values.
	 */
	void ButtonMapper () {
		// Vertical Movement.
		if (Input.GetKey (KeyCode.UpArrow)) {
			verticalBtn = 1;
			if (characterState == CharacterState.Jumping || characterState == CharacterState.WalkingOnAir) {
				characterState = CharacterState.WalkingOnAir;
			} else {
				characterState = CharacterState.Walking;
			}
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			verticalBtn = -1;
			if (characterState == CharacterState.Jumping || characterState == CharacterState.WalkingOnAir) {
				characterState = CharacterState.WalkingOnAir;
			} else {
				characterState = CharacterState.Walking;
			}
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
				if (characterState == CharacterState.Jumping || characterState == CharacterState.WalkingOnAir) {
					characterState = CharacterState.WalkingOnAir;
				} else {
					characterState = CharacterState.Walking;
				}

			} else if (Input.GetKey (KeyCode.A)) {
				horizontalBtn = -1;
				if (characterState == CharacterState.Jumping || characterState == CharacterState.WalkingOnAir) {
					characterState = CharacterState.WalkingOnAir;
				} else {
					characterState = CharacterState.Walking;
				}
			} else {
				horizontalBtn = 0;
			}
		}
	}

	/** 
	 * Movement Directions.
	 */
	void Movement () {
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
			if (Input.GetKey (KeyCode.F)) {
				moveDirection.y = jumpSpeed;
				characterState = CharacterState.Jumping;
				
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
		transform.Rotate (rotateDirection * Time.deltaTime);
	}

	/**
	 * Move on steep slope.
	 */
	void MoveOnSteepSlope () {

		if (characterState != CharacterState.Jumping && characterState != CharacterState.WalkingOnAir && standingOn != "Wall") {
			RaycastHit hit;

			Vector3 slopeAdjust = Vector3.zero;
	
			if (Physics.Raycast (transform.position, -Vector3.up, out hit)) {
				if (hit.distance < 5) {
					slopeAdjust.y = hit.distance - controller.height / 2;
				}
			}

			moveDirection -= slopeAdjust / Time.deltaTime;
		}


		if (standingOn == "Wall" && characterState == CharacterState.Walking && !controller.isGrounded) {
			characterState = CharacterState.WalkingOnAir;
		}

		if (standingOn == "Wall" && characterState != CharacterState.WalkingOnAir) {
			RaycastHit hit;

			Vector3 slopeAdjust = Vector3.zero;

			if (Physics.Raycast (transform.position, -Vector3.up, out hit)) {
				if (hit.distance < 2) {
					slopeAdjust.y = hit.distance - controller.height / 2;
				}
			}

			moveDirection -= slopeAdjust / Time.deltaTime;
		}

	}
}