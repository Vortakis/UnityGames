using UnityEngine;
using System.Collections;

/*
 * Camera following player:
 *  o First apply position tranformation to move camera to player's target position.
 *  o Second apply LookAt to force camera constantly look at the player.
 * 
 * Mathf.Lerp:
 *  o A class that Linearly interpolates between a and b by t(*speed).
 *  o The parameter t is clamped to the range [0, 1].
 *    - When t = 0 returns a. 
 *    - When t = 1 return b. 
 *    - When t = 0.5 returns the midpoint of a and b.
 */
public class Cameras : MonoBehaviour {

	public Transform player = null;
	public Transform target = null;

	public Vector3 speed = new Vector3 (4.0f, 2.0f, 1.0f);
	public Vector3 nextPosition = Vector3.zero;

	public enum CameraState {
		none,
		followPosition,
		lookAtPlayer,
		both}
	;

	public CameraState cameraState = CameraState.none;


	/*
	 * Late Update method.
	 */
	void LateUpdate () {
		switch (cameraState) {
			case CameraState.none:
				break;
			case CameraState.followPosition:
				FollowPosition ();
				break;
			case CameraState.lookAtPlayer:
				LookAtPlayer ();
				break;
			case CameraState.both:
				FollowPosition ();
				LookAtPlayer ();
				break;
		}
	}

	/*
	 * Its gonna make sure that the camera is going to stay smooth with the player.
	 */
	void FollowPosition () {
		nextPosition.x = Mathf.Lerp (this.transform.position.x, target.position.x, speed.x * Time.deltaTime);
		nextPosition.y = Mathf.Lerp (this.transform.position.y, target.position.y, speed.y * Time.deltaTime);
		nextPosition.z = Mathf.Lerp (this.transform.position.z, target.position.z, speed.z * Time.deltaTime);

		// Camera follows player at the position of the target.
		this.transform.position = nextPosition;
	}

	/*
	 * Always look at the player.
	 */
	void LookAtPlayer () {
		// Camera always looks at the player.
		this.transform.LookAt (player.position);
	}
}
