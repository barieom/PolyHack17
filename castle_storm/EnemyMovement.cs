using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public float initialSpeed = 1f;

	[HideInInspector]
	public bool inCombat = false;

	private float speed = 0;
	private float multiplierBtwnMoves = 0.0001f;

	/*********** PUBLIC FUNCTIONS ***********/

	public void StartMoveLeft()
	{
		if (!inCombat)
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-1 * initialSpeed, 0);
	}

	//NOTE: Castle module should have triggerbox to start enemy attack.

	public void EndMove()
	{
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
	}

	/********** PRIVATE FUNCTIONS ***********/

	private void Start()
	{
		StartMoveLeft ();
	}

	/*
	* Move the enemy.
	*/
	private void Update()
	{
		if (inCombat)
			return;

		StartMoveLeft ();
		
		Vector3 spot = transform.position;
		Vector3 destination = new Vector3 (spot.x + speed * multiplierBtwnMoves,
			spot.y,
			spot.z);

		transform.position = Vector3.MoveTowards(spot,
			destination,
			Time.deltaTime * speed);
	}
}
