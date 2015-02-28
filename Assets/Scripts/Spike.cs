using UnityEngine;
using System.Collections;

public class Spike : MonoBehaviour {

	GameObject player;
	PlayerH playerHealth;
	private bool playerInRange;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent<PlayerH> ();
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject == player)
			playerInRange = true;
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.gameObject == player)
			playerInRange = false;
	}

	void Update()
	{
		if (playerInRange)
			playerHealth.TakeDamage (500);
	}
}
