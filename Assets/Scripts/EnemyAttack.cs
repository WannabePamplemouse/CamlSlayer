using UnityEngine;
using System.Collections;


public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;     // The time in seconds between each attack.
    public int attackDamage = 10;               // The amount of health taken away per attack.
    private float prevScale;

    GameObject player;                          // Reference to the player GameObject.
    PlayerH playerHealth;                  		// Reference to the player's health.
    EnemyHealth enemyHealth;                    // Reference to this enemy's health.
    float timer;                                // Timer for counting up to the next attack.

    [SerializeField]
    private float xKnockBack;
    [SerializeField]
    private float yKnockBack;

    void Awake()
    {
        // Setting up the references.
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerH>();
        enemyHealth = GetComponent<EnemyHealth>();
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        // If the entering collider is the player...
        if (other.gameObject == player && timer >= timeBetweenAttacks)
        {
            // ... the player is in range.
            Attack();
        }
    }



    void Update()
    {
        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;

    }


    void Attack()
    {
        // Reset the timer.
        timer = 0f;

        // If the player has health to lose...
        if (playerHealth.currentHealth > 0)
        {
            // ... damage the player.
            playerHealth.TakeDamage(attackDamage);
        }

        if (player.transform.position.x > transform.position.x)
        {
            player.rigidbody2D.AddForce(new Vector2(xKnockBack, yKnockBack));
        }
        else
        {
            player.rigidbody2D.AddForce(new Vector2(-xKnockBack, yKnockBack));
        }
    }
}