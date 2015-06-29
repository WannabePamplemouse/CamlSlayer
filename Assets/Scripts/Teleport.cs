using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {
	
	public Transform target;
	public int enemiesToKill;
	public bool teleported;

	GameObject player;
	KillCount KC;
	GameObject portal;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
        if(player != null)
		    KC = player.GetComponent<KillCount>();
	}

    void Update()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
                KC = player.GetComponent<KillCount>();
        }
    }

	void OnTriggerEnter2D (Collider2D other)
    {
		if (other.tag == "Player" && KC.enemyKilled >= enemiesToKill && !teleported) {

			other.gameObject.transform.position = target.transform.position;
			target.GetComponent<Teleport>().teleported = true;
		}
	}

	void OnTriggerExit2D (Collider2D other){
		if (other.tag == "Player") {
			teleported = false;
		}
	}
}
