using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {
	
	public Transform target;


	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Player") {

			other.gameObject.transform.position = target.transform.position;
		}
	}
}
