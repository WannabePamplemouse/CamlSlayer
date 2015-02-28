using UnityEngine;
using System.Collections;
using UnitySampleAssets._2D;

public class Sword : MonoBehaviour {

	public float MaxDistance = 1000000000000;
	public int attackDamage = 100;

	GameObject player;
	PlatformerCharacter2D dir;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		dir = player.GetComponent<PlatformerCharacter2D> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q))
						attack ();
	}

	private void attack() {

		RaycastHit2D hit;

		if (dir.facingRight)
			hit = Physics2D.Raycast (transform.position, Vector2.right);
		else
			hit = Physics2D.Raycast (transform.position, -Vector2.right);


		if (hit.collider != null && Mathf.Abs (hit.point.x - transform.position.y) < MaxDistance && hit.transform.gameObject.tag == "Enemy") {
			GameObject enemy = hit.transform.gameObject;
			EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
			enemyHealth.TakeDamage(attackDamage);
		}
	}
}
