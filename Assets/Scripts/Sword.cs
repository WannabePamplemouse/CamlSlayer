using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {

	float MaxDistance = 1000000000000;
	int attackDamage = 100;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q))
						attack ();
	}

	private void attack() {
		RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.right);
		if (hit.collider != null && Mathf.Abs (hit.point.x - transform.position.y) < MaxDistance && hit.transform.gameObject.name == "Enemy") {
			GameObject enemy = hit.transform.gameObject;
			EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
			enemyHealth.TakeDamage(attackDamage);
		}
	}
}
