using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour {

	public int damage = 2;
	public float attackCooldown = 1.3f;

	[HideInInspector]
	public GameObject player = null;

	private bool canAttack = true;

	private EnemyMovement move;

	/*********** PUBLIC FUNCTIONS ***********/

	public void StartCombat(GameObject playerToFight)
	{
		player = playerToFight;
		move.EndMove ();
		move.inCombat = true;
	}

	public void Attack()
	{
		if (canAttack && player != null) {
			player.GetComponent<Health> ().ChangeHealth (damage);
			Debug.Log ("Attacking");
			StartCoroutine(WaitToAttack ());
			if (player == null || player.GetComponent<Health>().GetCurrentHealth() <= 0)
				EndCombat ();
		}
	}

	/********** PRIVATE FUNCTIONS ***********/

	private void Start()
	{
		move = GetComponent<EnemyMovement> ();
	}

	private void Update()
	{
		Attack ();
	}

	private void EndCombat()
	{
		move.inCombat = false;
		move.StartMoveLeft ();
	}

	private IEnumerator WaitToAttack()
	{
		canAttack = false;
		yield return new WaitForSeconds (attackCooldown);
		canAttack = true;
	}
}
