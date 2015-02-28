using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	public int startingHealth = 100;            // The amount of health the enemy starts the game with.
	public int currentHealth;     				// The current health the enemy has.

	GameObject player;
	KillCount KC;

	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		KC = player.GetComponent<KillCount> ();
		currentHealth = startingHealth;
	}
	
	void Update ()
	{
        if (transform.position.y < -15)
            Death();
	}
	
	
	public void TakeDamage (int amount)
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
		KC.enemyKilled ++;
        Destroy(gameObject);	
	}
}