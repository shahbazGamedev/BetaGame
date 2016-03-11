using UnityEngine;
using System.Collections;

public class GrabTargets : MonoBehaviour {

	public static bool count = 0;
	
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Targets") {
			count++;
			Destroy (collision.gameObject);
		}
	}
}
