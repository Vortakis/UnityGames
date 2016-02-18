using UnityEngine;
using System.Collections;

public class ThunderClap : MonoBehaviour
{
	public AudioClip clip;
	bool canFlicker = true;

	void Update ()
	{
		StartCoroutine (Flicker ());
	}

	IEnumerator Flicker ()
	{
		if ( canFlicker )
		{
			canFlicker = false;
			audio.PlayOneShot ( clip );
			light.enabled = true;
			yield return new WaitForSeconds ( Random.Range ( 0.1f, 0.4f ) );
			light.enabled = false;
			yield return new WaitForSeconds ( Random.Range ( 0.1f, 5 ) );
			canFlicker = true;
		}
	}
}
