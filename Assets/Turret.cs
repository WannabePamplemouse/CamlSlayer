using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

    [SerializeField]
    private float force;

    private bool playerInRange = false;
	
	// Update is called once per frame
	void Update () 
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.N))
        {
            shoot();
        }
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }

    void shoot()
    {
        GameObject bomb = GameObject.FindGameObjectWithTag("Boooom");
        bomb = (GameObject)Instantiate(bomb, transform.position, new Quaternion(0, 0, 0, 0));
        bomb.rigidbody2D.AddForce(new Vector2(0, force));
    }
}
