using UnityEngine;
using System.Collections;

public class RobotControllerScript : MonoBehaviour {

	private float maxSpeed = 10f;
	public bool facingRight = true;
	
	Animator anim;
	
	bool grounded = false;
	private Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
    [SerializeField]
	private float jumpForce = 700f;
	
	float timer;

	public bool isWorld1finished = false;
	public bool isWorld2finished = false;
	public bool isWorld3finished = false;
	public bool isWorld4finished = false;

	public bool haveSword = true;
	public bool haveBomb = false;
	public bool haveTromblon = false;


	public void SwitchBomb()
	{
		haveBomb = true;
		haveSword = false;
		haveTromblon = false;
		anim.SetBool ("haveBomb", true);
	}

	public void SwitchTromblon()
	{
		haveTromblon = true;
		haveBomb = false;
		haveSword = false;
		anim.SetBool ("haveTromblon", true);
	}

	public void SwitchSword()
	{
		haveSword = true;
		haveBomb = false;
		haveTromblon = false;
		anim.SetBool ("haveSword", true);
	}
	void Start () 
	{
		anim = GetComponent<Animator> ();
		groundCheck = transform.Find("GroundCheck");
	}
	
	
	void FixedUpdate () 
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);
		
		anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);
		
		
		float move = Input.GetAxis ("Horizontal");
		
		anim.SetFloat ("Speed", Mathf.Abs (move));
		
		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
		
		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();
	}
	
	void Update()
	{
        
		if (grounded && Input.GetKeyDown (KeyCode.Space)) 
		{
			grounded = false;
			anim.SetBool("Ground",false);
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
		}

		if(Input.GetKeyDown(KeyCode.B))
			SwitchBomb();

		if (isWorld1finished && Input.GetKeyDown (KeyCode.T))
			SwitchTromblon();

		if (Input.GetKeyDown (KeyCode.S))
			SwitchSword ();

		if (Input.GetKeyDown (KeyCode.Q)) 
		{
			timer = 0;
			anim.SetBool ("isAttacking", true);
		}
		
		timer += Time.deltaTime;
		
		if(timer > 0.50)
			anim.SetBool ("isAttacking", false);
        Physics2D.IgnoreLayerCollision(gameObject.layer, 19, !grounded || rigidbody2D.velocity.y > 0);
        
	}
	
	void Flip()
	{
		facingRight = !facingRight;
		
		Vector3 theScale = transform.localScale;	
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
