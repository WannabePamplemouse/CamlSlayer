using UnityEngine;
using System.Collections;

public class BulletEnemy4 : MonoBehaviour {

    [SerializeField]
    private int damage;

    void Awake()
    {
        Physics2D.IgnoreLayerCollision(gameObject.layer, gameObject.layer);
        Physics2D.IgnoreLayerCollision(gameObject.layer, 15);
        Physics2D.IgnoreLayerCollision(gameObject.layer, 16);
        Physics2D.IgnoreLayerCollision(gameObject.layer, 17);
        Physics2D.IgnoreLayerCollision(gameObject.layer, 21);
        Physics2D.IgnoreLayerCollision(gameObject.layer, 9);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerH>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
