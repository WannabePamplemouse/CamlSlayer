using UnityEngine;
using System.Collections;

public class Spike : MonoBehaviour {

	PlayerH playerHealth;
	EnemyHealth enemyHealth;

	void OnTriggerEnter2D (Collider2D other)
	{
        if (other.gameObject.tag == "Player")
            other.gameObject.GetComponent<PlayerH>().TakeDamage(500);
        else if (other.gameObject.tag == "Enemy")
        {
            enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(enemyHealth.currentHealth);
        }
	}
}
