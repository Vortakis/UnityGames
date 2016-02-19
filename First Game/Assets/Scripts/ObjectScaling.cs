using UnityEngine;
using System.Collections;

public class ObjectScaling : MonoBehaviour {

	public float scaleFactor = 3.0f;
	public Vector3 originalScale = Vector3.zero;

	void Awake () {
		originalScale = this.transform.localScale;
	}


	/*
	 * Update is called once per frame
	*/
	void Update () {
		if (Input.GetKeyDown (KeyCode.G)) {
			EnableScale ();
		} else if (Input.GetKeyUp (KeyCode.G)) {
			DisableScale ();
		}
	}

	public void EnableScale () {
		this.transform.localScale = Vector3.one * scaleFactor;
	}

	public void DisableScale () {
		this.transform.localScale = originalScale;
	}
}
