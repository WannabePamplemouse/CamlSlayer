using UnityEngine;
using System.Collections;

public class SawBlade : MonoBehaviour {

    private bool facing_left;
    private EnemyMove move;

	// Use this for initialization
	void Start () 
    {
        move = GetComponent<EnemyMove>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        facing_left = move.facing_left;
        if(facing_left) transform.Rotate(Vector3.back, -100 * Time.deltaTime);
        else transform.Rotate(Vector3.back, 100 * Time.deltaTime);
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            coll.GetComponent<PlayerH>().TakeDamage(30);
        }
    }
}
