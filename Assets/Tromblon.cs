using UnityEngine;
using System.Collections;
using UnitySampleAssets._2D;

public class Tromblon : MonoBehaviour {

    [SerializeField]
    private Vector2 forceBigBullet, forcePoulet;

    private PlatformerCharacter2D dir;
    private float timer = 0;
    private bool poulet = false;
    private PlayerEnergy energy;


	// Use this for initialization
	void Start () 
    {
        dir = GetComponentInParent<PlatformerCharacter2D>();
        energy = GetComponentInParent<PlayerEnergy>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(Input.GetKeyDown(KeyCode.Z) && energy.currentEnergy == energy.stratingEnergy)
        {
            poulet = !poulet;
            energy.currentEnergy = 0;
        }
        else if (timer != 0)
        {
            timer += Time.deltaTime;
            if (timer > 1.25)
            {
                timer = 0;
            }
        }
        else if(Input.GetKey(KeyCode.Q))
        {
            if (poulet) shootPoulet();
            else shoot();
        }
	}

    private void shoot()
    {
        timer = 0.1f;
        GameObject spike = GameObject.FindGameObjectWithTag("Boooom");
        spike = (GameObject)Instantiate(spike, gameObject.transform.position, new Quaternion(0, 0, 0, 0));
        if(dir.facingRight)
        {
            spike.rigidbody2D.AddForce(forceBigBullet);
        }
        else
        {
            spike.rigidbody2D.AddForce(new Vector2(-forceBigBullet.x, forceBigBullet.y));
        }
    }

    private void shootPoulet()
    {
        timer = 1f;
        GameObject spike = GameObject.FindGameObjectWithTag("Poulet");
        spike = (GameObject)Instantiate(spike, gameObject.transform.position, new Quaternion(0, 0, 0, 0));
        if (dir.facingRight)
        {
            spike.rigidbody2D.AddForce(forcePoulet);
        }
        else
        {
            spike.rigidbody2D.AddForce(new Vector2(-forcePoulet.x, forcePoulet.y));
        }
    }
}
