using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {
	
	public Transform target;
	public int enemiesToKill;

	GameObject player;
	KillCount KC;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		KC = player.GetComponent<KillCount>();
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Player" && KC.enemyKilled >= enemiesToKill) {

			other.gameObject.transform.position = target.transform.position;
		}
	}
}
