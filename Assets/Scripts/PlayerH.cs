using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerH : MonoBehaviour
{
	public int startingHealth = 100;                            // The amount of health the player starts the game with.
	public int currentHealth;                                   // The current health the player has.
	public Slider HealthSlider;                                 // Reference to the UI's health bar.
	public bool isDead;                                                // Whether the player is dead.
	bool damaged;                                               // True when the player gets damaged.
	
	
	void Awake ()
	{
		// Set the initial health of the player.
		currentHealth = startingHealth;
	}
	
	
	void Update ()
	{
        if (transform.position.y < -15)
            Death();
	}
	
	
	public void TakeDamage (int amount)
	{
		// Reduce the current health by the damage amount.
		currentHealth -= amount;
		
		// Set the health bar's value to the current health.
		HealthSlider.value = currentHealth;
		
		if(currentHealth <= 0 && !isDead)
		{
			// ... it should die.
			Death ();
		}
	}
	
	
	void Death ()
	{
		Destroy (gameObject);

		if (ToSettingsScript.isEnglish)
			Application.LoadLevel ("DeathScene");
		else
			Application.LoadLevel ("FrenchDeathScene");
	}       
}