using UnityEngine;
using System.Collections;


public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;     // The time in seconds between each attack.
    public int attackDamage = 10;               // The amount of health taken away per attack.
    private float prevScale;

    GameObject player;                          // Reference to the player GameObject.
    PlayerH playerHealth;                  		// Reference to the player's health.
    float timer;                                // Timer for counting up to the next attack.

    [SerializeField]
    private float xKnockBack;
    [SerializeField]
    private float yKnockBack;

    void Awake()
    {
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        // If the entering collider is the player...
        if (other.gameObject.tag == "Player" && timer >= timeBetweenAttacks)
        {
            // ... the player is in range.
            Attack(other);
        }
    }



    void Update()
    {
        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;

    }


    void Attack(Collision2D other)
    {
        PlayerH playerHealth = other.gameObject.GetComponent<PlayerH>();
        // Reset the timer.
        timer = 0f;

        // If the player has health to lose...
        if (playerHealth.currentHealth > 0)
        {
            // ... damage the player.
            playerHealth.TakeDamage(attackDamage);
        }

        if (other.gameObject.transform.position.x > transform.position.x)
        {
            other.gameObject.rigidbody2D.AddForce(new Vector2(xKnockBack, yKnockBack));
        }
        else
        {
            other.gameObject.rigidbody2D.AddForce(new Vector2(-xKnockBack, yKnockBack));
        }
    }
}