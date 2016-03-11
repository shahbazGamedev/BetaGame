using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour {

	NavMeshAgent navAgent;
	Animator anim;   
	Rigidbody playerRigidbody; 
	int shootableMask; 

	public GameObject shooting;
	public GameObject ak47;

	// Use this for initialization
	void Start () {
		navAgent = GetComponent<NavMeshAgent> ();
		anim = GetComponent <Animator> ();
		playerRigidbody = GetComponent <Rigidbody> ();
		ak47.SetActive (false);
		shootableMask = LayerMask.GetMask ("Shootable");
		shooting.SetActive(false);
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
			if (Physics.Raycast (ray, out hit)) {
				
				if (hit.transform.gameObject.tag == "Enemy") {
					Vector3 playerToMouse = hit.point - transform.position;
					playerToMouse.y = 0f;
					Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
					playerRigidbody.MoveRotation (newRotation);
					navAgent.SetDestination (transform.position);
					anim.SetBool ("shoot", true);
					ak47.SetActive (true);
					shooting.SetActive(true);
				} else {
					navAgent.SetDestination (hit.point);
					shooting.SetActive(false);
					anim.SetBool ("shoot", false);
					ak47.SetActive (false);
				}

			}

		}
	}

	void Animate() {
		if (anim.GetBool ("run") != navAgent.velocity.magnitude > 0.5f) {
			anim.SetBool ("run", navAgent.velocity.magnitude > 0.5f);
		}
	}

}
