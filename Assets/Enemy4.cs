using UnityEngine;
using System.Collections;
using System;

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
    private int force; 

    private GameObject player;
    private RobotControllerScript controller;
    private float timer = 2;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        controller = player.GetComponent<RobotControllerScript>();
        Physics2D.IgnoreLayerCollision(gameObject.layer, gameObject.layer);
        rb = GetComponent<Rigidbody2D>();
        scalex = transform.localScale.x;
        scaley = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        bool xtest = (transform.position.x - range < player.transform.position.x && player.transform.position.x < transform.position.x) ^ (transform.position.x + range > player.transform.position.x && player.transform.position.x > transform.position.x);
        bool ytest = !controller.grounded || (Math.Abs(player.transform.position.y - transform.position.y) < 1);
        if (xtest && ytest)
        {
            player_in_range = true;
        }
        else
        {
            player_in_range = false;
        }

        if(player_in_range)
        {
            rb.velocity = new Vector2(0,0);
            if(player.transform.position.x > transform.position.x)
            {
                facing_left = false;
                transform.localScale = new Vector3(-scalex, scaley, 1);
            }
            else
            {
                facing_left = true;
                transform.localScale = new Vector3(scalex, scaley, 1);
            }

            if(timer >= 2)
            {
                shoot();
                timer = 0;
            }
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

        if(timer < 2)
        {
            timer += Time.deltaTime;
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
            shoot_bullet.rigidbody2D.AddForce(new Vector2(-force, 0));
        }
        else
        {
            shoot_bullet.rigidbody2D.AddForce(new Vector2(force,0));
        }
    }
}
