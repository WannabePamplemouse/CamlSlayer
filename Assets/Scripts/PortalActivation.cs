using UnityEngine;
using System.Collections;

public class PortalActivation : MonoBehaviour {

	public int enemiesToKill;
	GameObject player;
	KillCount KC;

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
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D col) {
		if (KC.enemyKilled >= enemiesToKill) {
			particleSystem.renderer.sortingLayerName = "Ground";
			particleSystem.renderer.sortingOrder = 1000;
			particleSystem.enableEmission = true;
		}
	}
}
