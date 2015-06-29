using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

    GameObject player;
    Attacks attacks;
    EnemyHealth enHealth;

	// Use this for initialization
	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
            attacks = player.GetComponent<Attacks>();
        enHealth = GetComponentInParent<EnemyHealth>();
	}

    void Update()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
                attacks = player.GetComponent<Attacks>();
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject == player && attacks.doDamageOnHit)
        {
            enHealth.TakeDamage(attacks.damageOnCollision);
        }
    }
}
