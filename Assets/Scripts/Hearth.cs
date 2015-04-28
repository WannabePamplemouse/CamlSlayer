using UnityEngine;
using System.Collections;

public class Hearth : MonoBehaviour {

    [SerializeField]
    private int value = 10;

    void Start()
    {
        Physics2D.IgnoreLayerCollision(gameObject.layer, 14);
        Physics2D.IgnoreLayerCollision(gameObject.layer, 9);
        Physics2D.IgnoreLayerCollision(gameObject.layer, 17);
        Physics2D.IgnoreLayerCollision(gameObject.layer, 16);
    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            PlayerH health = coll.gameObject.GetComponent<PlayerH>();
            health.TakeDamage(-value);
            if (health.currentHealth > health.startingHealth)
            {
                health.currentHealth = health.startingHealth;
            }
            Destroy(gameObject);
        }
    }
}
