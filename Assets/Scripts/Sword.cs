using UnityEngine;
using System.Collections;
using UnitySampleAssets._2D;

public class Sword : MonoBehaviour {

	public float MaxDistance;
	public int attackDamage;
	public int EnergyCost;

	GameObject player;
	PlatformerCharacter2D dir;
	float timer;
	PlayerEnergy energy;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		dir = player.GetComponent<PlatformerCharacter2D> ();
		energy = player.GetComponent<PlayerEnergy>();
		renderer.enabled = false;
		timer = 0;
	}

	// Update is called once per frame
	void Update () {
		if (timer != 0) {
			timer += Time.deltaTime;
			if(timer > 1.25)
			{
				timer = 0;
				renderer.enabled = false;
			}
		}	
		else if (Input.GetKeyDown (KeyCode.Q))
						attack ();

	}

	private void attack() {

		if (energy.currentEnergy >= EnergyCost) {
			energy.UseEnergy (EnergyCost);

			renderer.enabled = true;
			timer = 1;

			RaycastHit2D hit;

			if (dir.facingRight)
				hit = Physics2D.Raycast (transform.position, Vector2.right, MaxDistance);
			else
				hit = Physics2D.Raycast (transform.position, -Vector2.right, MaxDistance);


			if (hit.collider != null && hit.transform.gameObject.tag == "Enemy") 
			{
				GameObject enemy = hit.transform.gameObject;
				EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
				enemyHealth.TakeDamage(attackDamage);
			}
		}
	}
}
