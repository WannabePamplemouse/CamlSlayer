using UnityEngine;
using System.Collections;

public class BossFinal : MonoBehaviour 
{

    bool p1 = true, p2 = false, p3 = false, facing_left = false, done_charging = true;
    EnemyHealth health;
    float timer = 0;
    Transform target;
    GameObject player;
    Rigidbody2D rb;
    PlayerH ph;

    [SerializeField]
    GameObject sb1, sb2, sb3; // à voir pour le nombre
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    Transform bullet_position;

	// Use this for initialization
	void Start () 
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
            target = player.transform;
        health = GetComponent<EnemyHealth>();
        rb = GetComponent<Rigidbody2D>();
        ph = player.GetComponent<PlayerH>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
                target = player.transform;
        }
        else
        {
            if (facing_left && target.position.x > transform.position.x)
            {
                facing_left = false;
                transform.localScale = new Vector2(1, 1);
            }
            else if (!facing_left && target.position.x <= transform.position.x)
            {
                facing_left = true;
                transform.localScale = new Vector2(-1, 1);
            }

            if (p2 && timer >= 2f)
            {
                movement();
                shoot_missile();
                timer = 0;
            }
            else if (p3 && timer >= 3 && done_charging)
            {
                done_charging = false;
                StartCoroutine(charge());
            }
            else if (!p1)
            {
                timer += Time.deltaTime;
            }
        }       
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(p3 && coll.gameObject == player)
        {
            ph.TakeDamage(20);
        }
    }

    void movement()
    {
        float yVel = 0, xVel = 0;

        if(transform.position.y != 18.5)
        {
            if(transform.position.y > 18.5)
            {
                yVel = -1;
            }
            else
            {
                yVel = 1;
            }
        }

        if(target.position.x - transform.position.x > 5)
        {
            xVel = 7;
        }
        else if(target.position.x - transform.position.x < 5)
        {
            xVel = -7;
        }

        rb.velocity = new Vector2(xVel, yVel);
    }

    void shoot_missile()
    {
        Vector2 dir = (target.position - transform.position).normalized;
        GameObject shoot_bullet = (GameObject)Instantiate(bullet, bullet_position.position, new Quaternion(0, 0, 0, 0));
        shoot_bullet.rigidbody2D.velocity = dir * 25;
    }

    IEnumerator charge()
    {      
        while (timer < 5)
        {
            Vector2 dir = (target.position - transform.position).normalized;
            rb.velocity = dir * 12;
            yield return 0;
        }
        done_charging = true;
        timer = 0;
        rb.velocity = new Vector2(0, 0);
    }

    public void switch_p(int p)
    {
        if(p == 1)
        {
            p1 = false;
            p2 = true;
            Destroy(sb1.gameObject);
            Destroy(sb2.gameObject);
            Destroy(sb3.gameObject);
            rb.gravityScale = 0;
        }
        else
        {
            p2 = false;
            p3 = true;
            Physics2D.IgnoreLayerCollision(14, 8);
        }
    }
}
