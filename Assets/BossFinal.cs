using UnityEngine;
using System.Collections;

public class BossFinal : MonoBehaviour 
{

    bool p1 = true, p2 = false, p3 = false, facing_left = false;
    EnemyHealth health;
    float timer = 0;
    Transform target;
    GameObject player;

    [SerializeField]
    SawBlade sb1, sb2; // à voir pour le nombre
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    Transform bullet_position;

	// Use this for initialization
	void Start () 
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
        health = GetComponent<EnemyHealth>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(facing_left && target.position.x > transform.position.x)
        {
            facing_left = false;
            transform.localScale = new Vector2(1, 1);

        }
        else if(!facing_left && target.position.x <= transform.position.x)
        {
            facing_left = true;
            transform.localScale = new Vector2(-1, 1);
        }

	    if(p2 && timer >= 1.5f) // test 1.5
        {
            shoot_missile();
            timer = 0;
        }
        else if(p3 && timer >= 5) // test 5
        {
            // actions de p3
        }
        else if(!p1)
        {
            timer += Time.deltaTime;
        }
	}

    void shoot_missile()
    {
        Vector2 dir = (target.position - transform.position).normalized;
        GameObject shoot_bullet = (GameObject)Instantiate(bullet, bullet_position.position, new Quaternion(0, 0, 0, 0));
        shoot_bullet.rigidbody2D.AddForce(dir);
    }

    public void switch_p(int p)
    {
        if(p == 1)
        {
            p1 = false;
            p2 = true;
            Destroy(sb1);
            Destroy(sb2);
        }
        else
        {
            p2 = false;
            p3 = true;
        }
    }
}
