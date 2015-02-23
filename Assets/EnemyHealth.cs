﻿using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	public int startingHealth = 100;            // The amount of health the enemy starts the game with.
	public int currentHealth;                   // The current health the enemy has.
	
	CapsuleCollider capsuleCollider;            // Reference to the capsule collider.
	bool isDead;                                // Whether the enemy is dead.
	
	void Awake ()
	{
		capsuleCollider = GetComponent <CapsuleCollider> ();
		
		// Setting the current health when the enemy first spawns.
		currentHealth = startingHealth;
	}
	
	void Update ()
	{
	}
	
	
	public void TakeDamage (int amount, Vector3 hitPoint)
	{
		// If the enemy is dead...
		if(isDead)
			// ... no need to take damage so exit the function.
			return;
		
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

		// Turn the collider into a trigger so shots can pass through it.
		capsuleCollider.isTrigger = true;
		
		Destroy (gameObject, 2f);
		
	}
}