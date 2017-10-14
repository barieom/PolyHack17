using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    private int MaxHealth = 10;
    private int currHealth;

    public void InitSetHealth()
    {
        currHealth = MaxHealth;
    }

    public void ChangeHealth(int i) {
        if (i < 0) {
            TakeDamage(-i);
        } else if (i > 0) {
            TakeDamage(i);
        }
    }

    public int GetHealth() {
        return currHealth;
    }


    /* PRIVATE FUNCTIONS */

    private void TakeDamage(int i) {
        currHealth = currHealth - i;
        if (currHealth <= 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
    
}
