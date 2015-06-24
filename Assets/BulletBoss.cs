using UnityEngine;
using System.Collections;

public class BulletBoss : MonoBehaviour {

    [SerializeField]
    private int damages;

    GameObject player;

    void Awake()
    {
        Physics2D.IgnoreLayerCollision(gameObject.layer, gameObject.layer);
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
