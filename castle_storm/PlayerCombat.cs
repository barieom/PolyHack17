using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour {

	public int damage = 5;
	public float blockTime = 1.5f;
	public float attackCooldown = 1.5f;
	public float blockCooldown = 5f;

	[HideInInspector]
	public GameObject enemy = null;

	private bool canAttack = true;
	private bool canBlock = true;
	private bool blocking = false;

	private Health hp;
	private PlayerMovement move;

	/*********** PUBLIC FUNCTIONS ***********/

	public void StartCombat(GameObject enemyToFight)
	{
		enemy = enemyToFight;
		enemy.GetComponent<EnemyCombat> ().StartCombat (gameObject);
		move.EndMove ();
		move.inCombat = true;
	}

	public void Attack()
	{
		if ((canAttack && !blocking) && enemy != null) {
			enemy.GetComponent<Health> ().ChangeHealth (damage);
			StartCoroutine(WaitToAttack ());
			if (enemy == null || enemy.GetComponent<Health>().GetCurrentHealth() <= 0)
				EndCombat ();
		}
	}

	public void Block()
	{
		if (canBlock && !blocking) {
			StartCoroutine(WaitWhileBlocking ());
			StartCoroutine(WaitToBlock ());
		}
	}

	/********** PRIVATE FUNCTIONS ***********/

	private void Start()
	{
		move = GetComponent<PlayerMovement> ();
		hp = GetComponent<Health> ();
	}

	private void EndCombat()
	{
		move.inCombat = false;
	}

	private IEnumerator WaitToAttack()
	{
		canAttack = false;
		yield return new WaitForSeconds (attackCooldown);
		canAttack = true;
	}

	private IEnumerator WaitToBlock()
	{
		canBlock = false;
		yield return new WaitForSeconds (blockCooldown);
		canBlock = true;
	}

	private IEnumerator WaitWhileBlocking()
	{
		blocking = true;
		hp.attackable = false;
		yield return new WaitForSeconds (blockTime);
		hp.attackable = true;
		blocking = false;
	}
}
