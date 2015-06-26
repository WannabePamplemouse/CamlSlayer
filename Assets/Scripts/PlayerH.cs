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
	public bool canTakeDamage = true;
    public bool canDash = true;


    // Handle camera shaking
    public float camShakeAmt = 0.3f;
    public float camShakeLength = 0.1f;
    CameraShake camShake;

	void Awake ()
	{
		// Set the initial health of the player.
		currentHealth = startingHealth;
        camShake = GetComponent<CameraShake>();
        if (camShake == null)
            Debug.LogError("No CameraShake script found on GM object.");
	}


	void Update ()
	{
        if (transform.position.y < -30)
            Death();
	}
	
	
	public void TakeDamage (int amount)
	{
		if(canTakeDamage || amount < 0){
			// Reduce the current health by the damage amount.
			currentHealth -= amount;
			
			// Set the health bar's value to the current health.
			HealthSlider.value = currentHealth;
			
			if(currentHealth <= 0 && !isDead)
			{
				// ... it should die.
				Death ();
			}

            //shake the camera
            if (amount > 0)
                camShake.Shake(camShakeAmt, camShakeLength);
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