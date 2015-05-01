using UnityEngine;
using System.Collections;

public class Attacks : MonoBehaviour {

    private PlayerEnergy energy;
    private Inventory inventory;
    private RobotControllerScript controller;
    private PlayerH playerHealth;

    [SerializeField]
    private int attackEnergyCost;
    [SerializeField]
    private float MaxDistanceSword;
    [SerializeField]
    private int attackDamageSword;

    [SerializeField]
    private int dashEnergyCost;
    [SerializeField]
    private float dashSpeed;

    [SerializeField]
    private Vector2 forceBomb, forceBigBullet, forcePoulet;

    public bool doDamageOnHit = false;
    public int damageOnCollision = 0;

	// Use this for initialization
	void Start () 
    {
        energy = GetComponent<PlayerEnergy>();
        playerHealth = GetComponent<PlayerH>();
        controller = GetComponent<RobotControllerScript>();
        inventory = GetComponent<Inventory>();
	}
	
    public void attackSword()
    {
        if (energy.currentEnergy >= attackEnergyCost)
        {
            energy.UseEnergy(attackEnergyCost);
            RaycastHit2D hit;
            gameObject.layer = 2;

            if (controller.facingRight)
                hit = Physics2D.Raycast(transform.position, Vector2.right, MaxDistanceSword);
            else
                hit = Physics2D.Raycast(transform.position, -Vector2.right, MaxDistanceSword);

            gameObject.layer = 10;

            if (hit.collider != null && hit.transform.gameObject.tag == "Enemy")
            {
                GameObject enemy = hit.transform.gameObject;
                EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
                enemyHealth.TakeDamage(attackDamageSword);
            }
        }
    }

    public IEnumerator dash(float dur)
    {
        if (energy.currentEnergy >= dashEnergyCost)
        {
            Physics2D.IgnoreLayerCollision(9, gameObject.layer);
            doDamageOnHit = true;
            playerHealth.canTakeDamage = false;
            playerHealth.canDash = false;
            damageOnCollision = 50;
            float time = 0;

            energy.UseEnergy(dashEnergyCost);

            float realDashSpeed;
            if (controller.facingRight)
                realDashSpeed = dashSpeed;
            else
                realDashSpeed = -dashSpeed;

            while (time < dur)
            {
                time += Time.deltaTime;
                rigidbody2D.velocity = new Vector2(realDashSpeed, 0);
                yield return 0;
            }

            doDamageOnHit = false;
            playerHealth.canTakeDamage = true;
            playerHealth.canDash = true;
            damageOnCollision = 0;
            Physics2D.IgnoreLayerCollision(9, gameObject.layer, false);
        }
    }

    public void shootPoulet()
    {
        GameObject spike = GameObject.FindGameObjectWithTag("Poulet");
        spike = (GameObject)Instantiate(spike, gameObject.transform.position, new Quaternion(0, 0, 0, 0));
        spike.GetComponent<AudioSource>().Play();
        if (controller.facingRight)
        {
            spike.rigidbody2D.AddForce(forcePoulet);
        }
        else
        {
            spike.rigidbody2D.AddForce(new Vector2(-forcePoulet.x, forcePoulet.y));
        }
    }

    public void shootBigBullet()
    {
        GameObject spike = GameObject.FindGameObjectWithTag("Boooom");
        spike = (GameObject)Instantiate(spike, gameObject.transform.position, new Quaternion(0, 0, 0, 0));
        if (controller.facingRight)
        {
            spike.rigidbody2D.AddForce(forceBigBullet);
        }
        else
        {
            spike.rigidbody2D.AddForce(new Vector2(-forceBigBullet.x, forceBigBullet.y));
        }
    }

    public void shootBomb()
    {
        inventory.GetBombs(-1);
        GameObject spike = GameObject.FindGameObjectWithTag("Boooom");
        spike = (GameObject)Instantiate(spike, gameObject.transform.position, new Quaternion(0, 0, 0, 0));
        if (controller.facingRight)
        {
            spike.rigidbody2D.AddForce(forceBomb);
        }
        else
        {
            spike.rigidbody2D.AddForce(new Vector2(-forceBomb.x, forceBomb.y));
        }
    }
}
