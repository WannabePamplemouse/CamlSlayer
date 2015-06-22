using UnityEngine;
using System.Collections;

public class Enemy4 : MonoBehaviour 
{

    [SerializeField]
    private float speed; // speed
    [SerializeField]
    private int left; // min x position
    [SerializeField]
    private int right; // max x position

    private float scalex, scaley;
    private Rigidbody2D rb;

    public bool facing_left = true;

    private bool player_in_range = false;

    [SerializeField]
    private int range;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform bullet_position;
    [SerializeField]
    private Vector2 force; 

    private GameObject player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreLayerCollision(gameObject.layer, gameObject.layer);
        rb = GetComponent<Rigidbody2D>();
        scalex = transform.localScale.x;
        scaley = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x - range > player.transform.position.x || transform.position.x + range < player.transform.position.x)
        {
            player_in_range = true;
        }
        else
        {
            player_in_range = false;
        }

        if(player_in_range)
        {
            if(player.transform.position.x > transform.position.x)
            {
                facing_left = false;
                transform.localScale = new Vector3(scalex, scaley, 1);
            }
            else
            {
                facing_left = false;
                transform.localScale = new Vector3(-scalex, scaley, 1);
            }

            InvokeRepeating("shoot", 2, 2);
        }
        else
        {
            if (!facing_left && transform.position.x >= right)
            {
                facing_left = true;
                transform.localScale = new Vector3(scalex, scaley, 1);
            }
            else if (facing_left && transform.position.x <= left)
            {
                facing_left = false;
                transform.localScale = new Vector3(-scalex, scaley, 1);
            }

            movement();
        }
    }

    private void movement()
    {
        float y = rb.velocity.y;
        if (y > 0) y = 0;
        Vector3 dir = new Vector3(2, y, 0);

        if (facing_left)
        {
            dir *= -1;
        }

        dir *= speed * Time.fixedDeltaTime;
        rb.velocity = dir;
    }

    private void shoot()
    {
        GameObject shoot_bullet = (GameObject)Instantiate(bullet, bullet_position.position, new Quaternion(0, 0, 0, 0));
        if (facing_left)
        {
            shoot_bullet.rigidbody2D.AddForce(new Vector2(- force.x, force.y));
        }
        else
        {
            shoot_bullet.rigidbody2D.AddForce(force);
        }
    }
}
