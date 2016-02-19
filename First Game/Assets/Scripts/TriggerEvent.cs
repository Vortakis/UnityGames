using UnityEngine;
using System.Collections;

/*
 *   In order for a Trigger Even to occur, the moving object 
 *   needs to have a RigidBody. 
 */
public class TriggerEvent : MonoBehaviour {

	/* Objects interacting with script. */
	public GameObject lightBulb = null;
	public GameObject wall = null;
	public AudioClip lightBulbAudio = null;

	/* Change light bulb light colour variables. */
	private Color[] lightColours = { Color.white, Color.red, Color.green, Color.blue };
	private int maxTimer = 30;
	private int timer = 30;
	private int index = 0;

	void OnTriggerEnter (Collider other) {
		if (other.name == "Player") {
			// LightBulb spotlight activate.
			lightBulb.SetActive (true);

			// LightSwitch Sound On.
			this.GetComponent<AudioSource> ().PlayOneShot (lightBulbAudio);

			// Wall Colouring and Scaling On.
			wall.GetComponent<ObjectScaling> ().EnableScale ();
			wall.GetComponent<ObjectColour> ().EnableColour ();
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.name == "Player") {
			// LightBulb spotlight deactivate.
			lightBulb.SetActive (false);

			// LightSwitch Sound Off.
			this.GetComponent<AudioSource> ().Stop ();

			// Wall Colouring and Scaling Off.
			wall.GetComponent<ObjectScaling> ().DisableScale ();
			wall.GetComponent<ObjectColour> ().DisableColour ();
		}
	}

	void OnTriggerStay (Collider other) {
		if (other.name == "Player") {
			ChangeLightColour ();
		}
	}

	public void ChangeLightColour () {
		if (timer == maxTimer) {
			lightBulb.GetComponent<Light> ().color = lightColours [index];
			index++;
			if (index == lightColours.Length) {
				index = 0;
			}
			timer = 0;
		} else {
			timer++;
		}
	}
}
