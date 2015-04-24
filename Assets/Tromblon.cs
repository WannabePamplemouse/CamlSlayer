using UnityEngine;
using System.Collections;
using UnitySampleAssets._2D;

public class Tromblon : MonoBehaviour {

    [SerializeField]
    private Vector2 forceBigBullet, forcePoulet;
    private PlatformerCharacter2D dir;
    private float timer = 0;
    private Sword sword;
    private GameObject player;
    private bool poulet = false;

	// Use this for initialization
	void Start () 
    {
        player = GameObject.FindGameObjectWithTag("Player");
        dir = GetComponentInParent<PlatformerCharacter2D>();
        sword = player.GetComponentInChildren<Sword>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (timer != 0)
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
        else if(Input.GetKeyDown(KeyCode.Z))
        {
            poulet = !poulet;
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
