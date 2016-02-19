using UnityEngine;
using System.Collections;

public class ObjectColour : MonoBehaviour {

	public Color changedColor = Color.red;
	private Color originalColor = Color.white;

	// Use this for initialization
	void Awake () {
		originalColor = this.GetComponent<Renderer> ().material.color;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.G)) {
			EnableColour ();
		} else if (Input.GetKeyUp (KeyCode.G)) {
			DisableColour ();
		}
	}

	public void EnableColour () {
		this.GetComponent<Renderer> ().material.color = changedColor;
	}

	public void DisableColour () {		
		this.GetComponent<Renderer> ().material.color = originalColor;
	}
}
