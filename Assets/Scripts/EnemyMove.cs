using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

	[SerializeField] private float speed = 300f; // speed
	[SerializeField] private int right; // max x position
	[SerializeField] private int left; // min x position

	private ForceMode2D fmode;
	private Rigidbody2D rb;

	private bool facing_left = true;

	// Use this for initialization
	void Start ()
    {
		rb = GetComponentInParent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (!facing_left && transform.position.x > right)
        {
			facing_left = true;
			transform.localScale = new Vector3(1,1,1);
		}
		else if(facing_left && transform.position.x < left)
        {
			facing_left = false;
			transform.localScale = new Vector3(-1,1,1);
		}

		movement ();
	}

	private void movement()
    {
		Vector3 dir = new Vector3 (2, rb.velocity.y, 0);

		if (facing_left)
        {
			dir *= -1;
		}

		dir *= speed * Time.fixedDeltaTime;
		rb.velocity = dir;
	}
}
