using UnityEngine;
using System.Collections;

public class BulletEnemy4 : MonoBehaviour {

    [SerializeField]
    private int damage;

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
