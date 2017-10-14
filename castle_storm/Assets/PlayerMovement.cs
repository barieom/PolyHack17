using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float initialSpeed = 1f;

	[HideInInspector]
	public bool inCombat = false;

	private float speed = 0;
	private float multiplierBtwnMoves = 0.0001f;

	/*********** PUBLIC FUNCTIONS ***********/

	public void StartMoveLeft()
	{
		if (!inCombat) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-1 * initialSpeed, 0);
			transform.localScale = new Vector3 (-1, 1, 1);
		}
	}

	public void StartMoveRight()
	{
		if (!inCombat) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (initialSpeed, 0);
			transform.localScale = new Vector3 (1, 1, 1);
		}
	}

	public void EndMove()
	{
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
	}

	/********** PRIVATE FUNCTIONS ***********/

	/*
	 * Move the player.
	 */
	private void Update()
	{
		if (inCombat)
			return;
		
		Vector3 spot = transform.position;
		Vector3 destination = new Vector3 (spot.x + speed * multiplierBtwnMoves,
			                               spot.y,
			                               spot.z);

		transform.position = Vector3.MoveTowards(spot,
			                                     destination,
												 Time.deltaTime * speed);
	}
}
