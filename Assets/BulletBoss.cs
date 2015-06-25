using UnityEngine;
using System.Collections;

public class BulletBoss : MonoBehaviour {

    [SerializeField]
    private int damages;

    GameObject player;

    void Awake()
    {
        Physics2D.IgnoreLayerCollision(gameObject.layer, gameObject.layer);
        Physics2D.IgnoreLayerCollision(gameObject.layer, 15);
        Physics2D.IgnoreLayerCollision(gameObject.layer, 16);
        Physics2D.IgnoreLayerCollision(gameObject.layer, 17);
        Physics2D.IgnoreLayerCollision(gameObject.layer, 21);
        Physics2D.IgnoreLayerCollision(gameObject.layer, 14);
        player = GameObject.FindGameObjectWithTag("Player");
    }

	void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject == player)
        {
            player.GetComponent<PlayerH>().TakeDamage(damages);
        }

        Destroy(gameObject);
    }
}
