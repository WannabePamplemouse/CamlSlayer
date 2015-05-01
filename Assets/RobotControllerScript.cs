using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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

    private PlayerEnergy energy;
    private Inventory inventory;
    private Attacks attacks;

	private bool poulet = false;
	
	float timer, timer2 = 0;

	public bool isWorld1finished = false;
	public bool isWorld2finished = false;
	public bool isWorld3finished = false;
	public bool isWorld4finished = false;

	public bool haveSword;
	public bool haveBomb;
	public bool haveTromblon;

	static private string bombCommandFinal;
	static private string swordCommandFinal;
	static private string gunCommandFinal;
	static private string attackCommandFinal;

	void Start () 
	{
        energy = GetComponent<PlayerEnergy>();
		anim = GetComponent<Animator> ();
        inventory = GetComponent<Inventory>();
        attacks = GetComponent<Attacks>();

		groundCheck = transform.Find("GroundCheck");

		haveBomb = false;
		haveSword = true;
		haveTromblon = false;

		bombCommandFinal = UIManagerScript.bombCommand;
		swordCommandFinal = UIManagerScript.swordCommand;
		gunCommandFinal = UIManagerScript.gunCommand;
		attackCommandFinal = UIManagerScript.attackCommand;


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

		if (Input.GetKeyDown ((KeyCode)System.Enum.Parse (typeof(KeyCode), bombCommandFinal)))
			SwitchBomb ();

		else if (isWorld1finished && Input.GetKey ((KeyCode)System.Enum.Parse (typeof(KeyCode), gunCommandFinal)))
			SwitchTromblon ();

		else if (Input.GetKeyDown ((KeyCode)System.Enum.Parse (typeof(KeyCode), swordCommandFinal)))
			SwitchSword ();

		else if (haveSword && Input.GetKeyDown ((KeyCode)System.Enum.Parse (typeof(KeyCode), attackCommandFinal)) && timer2 > 0.5) 
        {
			timer = 0;
            timer2 = 0;
            anim.SetBool("isAttacking", true);
		} 
        else if (haveTromblon && Input.GetKey ((KeyCode)System.Enum.Parse (typeof(KeyCode), attackCommandFinal))) 
        {
			if (poulet && timer2 > 0.1)
				attacks.shootPoulet ();
			else if(timer2 > 1)
				attacks.shootBigBullet ();
		}
        else if (haveSword && Input.GetKeyDown ((KeyCode)System.Enum.Parse (typeof(KeyCode), "Y")) && timer2 > 0.5)
        {
			timer = 0;
            timer2 = 0;
			attacks.dash (0.2f);
		} 
        else if (haveTromblon && Input.GetKeyDown ((KeyCode)System.Enum.Parse (typeof(KeyCode), "Y")) && energy.currentEnergy == energy.stratingEnergy) 
        {
			poulet = !poulet;
            energy.currentEnergy = 0;
		} 
        else if (haveBomb && Input.GetKeyDown ((KeyCode)System.Enum.Parse (typeof(KeyCode), attackCommandFinal)) && timer2 > 0.5 && inventory.canBomb()) 
        {
			timer = 0;
            timer2 = 0;
			anim.SetBool ("isAttacking", true);
		}

		
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;

		if (haveSword && timer > 0.50)
			anim.SetBool ("isAttacking", false);
		else if (haveBomb && timer > 0.35)
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

    public void SwitchBomb()
    {
        haveBomb = true;
        haveSword = false;
        haveTromblon = false;
        anim.SetBool("haveBomb", true);
		anim.SetBool ("haveSword", false);
		anim.SetBool ("haveTromblon", false);
    }

    public void SwitchTromblon()
    {
        haveTromblon = true;
        haveBomb = false;
        haveSword = false;
        anim.SetBool("haveTromblon", true);
		anim.SetBool ("haveSword", false);
		anim.SetBool ("haveBomb", false);
    }

    public void SwitchSword()
    {
        haveSword = true;
        haveBomb = false;
        haveTromblon = false;
        anim.SetBool("haveSword", true);
		anim.SetBool ("haveBomb", false);
		anim.SetBool ("haveTromblon", false);
    }
}
