using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int initialHealth = 20;
    public int maxHealth = 20;

	[HideInInspector]
	public bool attackable = true;

	private int currentHealth;

	/*********** PUBLIC FUNCTIONS ***********/

	/*
	 * To take damage, give positive health.
	 * To heal, give negative health.
	 */
	public void ChangeHealth(int amt)
	{
		if (amt == 0)
			return;
		else if (amt > 0 && attackable)
			TakeDamage (amt);
		else if (amt < 0)
			Heal (amt);
	}

	public int GetCurrentHealth()
	{
		return currentHealth;
	}

	/********** PRIVATE FUNCTIONS ***********/

	private void Start()
	{
		currentHealth = initialHealth;
	}

	private void TakeDamage(int amt)
	{
		currentHealth -= amt;
		if (currentHealth <= 0)
			Die ();
	}

	private void Heal(int amt)
	{
		currentHealth += amt;
		if (currentHealth > maxHealth)
			currentHealth = maxHealth;
	}

	private void Die()
	{
		Destroy (gameObject);
	}
}
