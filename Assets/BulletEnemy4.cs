using UnityEngine;
using System.Collections;

public class BulletEnemy4 : MonoBehaviour {

    [SerializeField]
    private int damage;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerH>().TakeDamage(damage);
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
