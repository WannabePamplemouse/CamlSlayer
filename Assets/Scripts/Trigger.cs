using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

    GameObject player;
    Sword sword;
    EnemyHealth enHealth;

	// Use this for initialization
	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player");
        sword = player.GetComponentInChildren<Sword>();
        enHealth = GetComponentInParent<EnemyHealth>();
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject == player && sword.doDamageOnHit)
        {
            enHealth.TakeDamage(sword.damageOnCollision);
        }
    }
}
