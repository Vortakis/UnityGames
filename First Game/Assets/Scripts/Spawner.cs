using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject spawnType = null;
	public float scaleMin = 0.2f;
	public float scaleMax = 1.0f;
	private float scaleSize;
	public float force = 125.0f;


	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			GameObject obj = Instantiate (spawnType) as GameObject;
			obj.name = "mySphere";
			obj.transform.position = this.transform.position;
			randomScale ();
			obj.transform.localScale = Vector3.one * scaleSize;
			obj.AddComponent<Rigidbody> ();
			obj.GetComponent<Rigidbody> ().AddRelativeForce (Vector3.back * force);
		}
	}

	public void randomScale () {
		scaleSize = Random.Range (scaleMin, scaleMax);
	}
}
