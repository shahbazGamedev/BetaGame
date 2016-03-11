using UnityEngine;
using System.Collections;

public class GrabTargets : MonoBehaviour {

	public static int count = 0;
	
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Targets") {
			count = count + 1;
			Destroy (collision.gameObject);
		}
	}
}
