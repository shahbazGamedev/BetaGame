using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour {

	NavMeshAgent navAgent;
	Animator anim;   
	// Use this for initialization
	void Start () {
		navAgent = GetComponent<NavMeshAgent> ();
		anim = GetComponent <Animator> ();
	}

	void FixedUpdate() {

	}

	// Update is called once per frame
	void Update () {
		Move ();
		Animate ();
	}

	void Move() {
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		if (Input.GetMouseButtonUp (0)) {
			if (Physics.Raycast (ray, out hit, 100)) {
				Debug.Log ("Hello");
				navAgent.SetDestination (hit.point);
			}
		}
	}

	void Animate() {
		if (anim.GetBool ("run") != navAgent.velocity.magnitude > 0.5f) {
			anim.SetBool ("run", navAgent.velocity.magnitude > 0.5f);
		}
	}
}
