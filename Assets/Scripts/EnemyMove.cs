using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

	[SerializeField] private float speed; // speed
    [SerializeField] private int left; // min x position
	[SerializeField] private int right; // max x position

    private float scalex, scaley;
	private Rigidbody2D rb;

	public bool facing_left = true;

	// Use this for initialization
	void Start ()
    {
        Physics2D.IgnoreLayerCollision(gameObject.layer, gameObject.layer);
		rb = GetComponentInParent<Rigidbody2D> ();
        scalex = transform.localScale.x;
        scaley = transform.localScale.y;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (!facing_left && transform.position.x >= right)
        {
			facing_left = true;
			transform.localScale = new Vector3(scalex,scaley,1);
		}
		else if(facing_left && transform.position.x <= left)
        {
			facing_left = false;
			transform.localScale = new Vector3(-scalex,scaley,1);
		}

		movement ();
	}

	private void movement()
    {
        float y = rb.velocity.y;
        if (y > 0) y = 0;
		Vector3 dir = new Vector3 (2, y, 0);

		if (facing_left)
        {
			dir *= -1;
		}

		dir *= speed * Time.fixedDeltaTime;
		rb.velocity = dir;
	}
}
