using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	public int startingHealth = 100;            // The amount of health the enemy starts the game with.
	public int currentHealth;                   // The current health the enemy has.
	
	bool isDead;                                // Whether the enemy is dead.
	
	void Awake ()
	{
		// Setting the current health when the enemy first spawns.
		currentHealth = startingHealth;
	}
	
	void Update ()
	{
        if (transform.position.y < -15)
            Death();
	}
	
	
	public void TakeDamage (int amount, Vector3 hitPoint)
	{
		// Reduce the current health by the amount of damage sustained.
		currentHealth -= amount;
		
		// If the current health is less than or equal to zero...
		if(currentHealth <= 0)
		{
			// ... the enemy is dead.
			Death ();
		}
	}
	
	
	void Death ()
	{
		// The enemy is dead.
		isDead = true;

        Destroy(gameObject);
		
	}
}