using UnityEngine;
using System.Collections;

public class ZombieMovement : MonoBehaviour {

	public float zombieAttackDistance;

	Transform player;
	//PlayerHealth playerHealth;
	ZombieHealth zombieHealth;
	ZombieAttack zombieAttack;
	NavMeshAgent nav;
	Animator anim;


	void Awake ()
	{
		// Set up the references.
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		zombieHealth = GetComponent<ZombieHealth> ();
		zombieAttack = GetComponent<ZombieAttack> ();

		nav = GetComponent <NavMeshAgent> ();
		anim = GetComponent<Animator> ();
	}


	void Update ()
	{
		if (zombieAttackDistance < 5) {
			anim.SetBool ("Attack", true);
			anim.SetBool ("Walk", false);
		} else {
			anim.SetBool ("Walk", true);
			anim.SetBool ("Attack", false);
			nav.SetDestination (player.position);
		}
		// If the enemy and the player have health left...
		//if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
		//{
			// ... set the destination of the nav mesh agent to the player.
		//	nav.SetDestination (player.position);
		//}
		// Otherwise...
		//else
	//	{
			// ... disable the nav mesh agent.
		//	nav.enabled = false;
	//	}
	}

}
