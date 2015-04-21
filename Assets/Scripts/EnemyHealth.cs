﻿using UnityEngine;
using UnityEngine.UI;
using System;

public class EnemyHealth : MonoBehaviour
{
	public int startingHealth = 100;            // The amount of health the enemy starts the game with.
	public int currentHealth;     				// The current health the enemy has.

    [SerializeField] Slider HealthSlider;
	GameObject player;
	KillCount KC;
	EnemyHealth enemyHealth;

    [SerializeField] 
    private float xHearthforce;
    [SerializeField]
    private float yHearthforce;

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
        HealthSlider.value = currentHealth;
		// If the current health is less than or equal to zero...
		if(currentHealth <= 0)
		{
			// ... the enemy is dead.
			Death ();
		}
	}
	
	
	void Death ()
	{
        GameObject hearth = GameObject.FindGameObjectWithTag("Hearth");
        System.Random rand = new System.Random();
        for (int i = rand.Next(1, 4); i > 0; i--)
        {
            GameObject created = (GameObject)Instantiate(hearth, transform.position, new Quaternion(0f, 0f, 0f, 0f));
            int a = rand.Next(1,11);
            if(a > 5) a = -a + 5;
            int b = rand.Next(1, 6);
            created.rigidbody2D.AddForce(new Vector2(xHearthforce * a, yHearthforce * b));       
        }
        
        
		KC.enemyKilled ++;
        Destroy(gameObject);	
	}
}