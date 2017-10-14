using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxStartCombat : MonoBehaviour {

	/*
	 *  NOTE: Attach this script to a child of a battlefield player. The child
	 *        should have a 2D collider and a Rigidbody2D.
	 */

	private bool colliding = false;

	private PlayerCombat parentCombat;
	private PlayerMovement parentMove;

	/********** PRIVATE FUNCTIONS ***********/

	private void Start ()
	{
		parentCombat = GetComponentInParent<PlayerCombat> ();
		parentMove = GetComponentInParent<PlayerMovement> ();
	}

	private void Update ()
	{
		if (!parentMove.inCombat)
			colliding = false;
	}

	private void OnTriggerEnter2D (Collider2D other)
	{
		if (!colliding) {
			colliding = true;
			parentCombat.StartCombat (other.gameObject);
			other.gameObject.GetComponent<EnemyCombat> ().StartCombat (transform.parent.gameObject);
		}
	}
}
