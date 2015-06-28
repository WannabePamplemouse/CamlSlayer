using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class RobotControllerScript : MonoBehaviour {

    private float lastSynchronizationTime = 0f;
    private float syncDelay = 0f;
    private float syncTime = 0f;
    private Vector3 syncStartPosition = Vector3.zero;
    private Vector3 syncEndPosition = Vector3.zero;


	private float maxSpeed = 10f;
	public bool facingRight = true;
	
	Animator anim;
	
	public bool grounded = false;
	private Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;

    [SerializeField]
	private float jumpForce = 700f;

    private PlayerEnergy energy;
    private Inventory inventory;
    private Attacks attacks;
    private PlayerH playerHealth;

	private bool poulet = false, cochon = false;
	
	float timer, timer2 = 0;

	public static bool isWorld1finished;
	public static bool isWorld2finished;
	public static bool isWorld3finished;

	public bool haveSword = true;
	public bool haveBomb = false;
	public bool haveTromblon = false;

	static private string bombCommandFinal;
	static private string swordCommandFinal;
	static private string gunCommandFinal;
	static private string attackCommandFinal;
	static private string firstAbilityFinal;

	private bool isMulti;
	GameObject multiGun;

	void Start () 
	{
        energy = GetComponent<PlayerEnergy>();
		anim = GetComponent<Animator> ();
        inventory = GetComponent<Inventory>();
        attacks = GetComponent<Attacks>();
        playerHealth = GetComponent<PlayerH>();

		groundCheck = transform.Find("GroundCheck");

		isWorld1finished = UIManagerScript.isWorld1finished;
		isWorld2finished = UIManagerScript.isWorld2finished;
		isWorld3finished = UIManagerScript.isWorld3finished;

		bombCommandFinal = UIManagerScript.bombCommand;
		swordCommandFinal = UIManagerScript.swordCommand;
		gunCommandFinal = UIManagerScript.gunCommand;
		attackCommandFinal = UIManagerScript.attackCommand;
		firstAbilityFinal = UIManagerScript.firstAbility;

		isMulti = NetworkManager.isMulti;
		if (isMulti) 
		{
			if(NetworkManager2.isRobotGun)
				multiGun = Instantiate(Resources.Load("Prefabs/MultiGun")) as GameObject;
		}
	}
	
	void FixedUpdate () 
	{
        Physics2D.IgnoreLayerCollision(gameObject.layer, 19, !grounded && !(rigidbody2D.velocity.y < 0) );
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);
		
		if (NetworkManager.Robot != this.gameObject && isMulti)
			return;
		anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);
		
		float move = Input.GetAxis ("Horizontal");
		
		anim.SetFloat ("Speed", Mathf.Abs (move));
		
        if(playerHealth.canDash)
		    rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
		
		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();


	}


	void Update()
	{   

		if (NetworkManager.Robot != this.gameObject && isMulti)
			return;

		//getting the commands if they are changing in game
		bombCommandFinal = UIManagerScript.bombCommand;
		swordCommandFinal = UIManagerScript.swordCommand;
		gunCommandFinal = UIManagerScript.gunCommand;
		attackCommandFinal = UIManagerScript.attackCommand;
		firstAbilityFinal = UIManagerScript.firstAbility;

		if (grounded && Input.GetKeyDown (KeyCode.Space)) 
		{
			grounded = false;
			anim.SetBool("Ground",false);
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
		}

	    if (Input.GetKeyDown ((KeyCode)System.Enum.Parse (typeof(KeyCode), bombCommandFinal)))
			SwitchBomb ();

		else if (Input.GetKey ((KeyCode)System.Enum.Parse (typeof(KeyCode), gunCommandFinal))) //SwitchTromblon, dispo M1
			SwitchTromblon ();

		else if (Input.GetKeyDown ((KeyCode)System.Enum.Parse (typeof(KeyCode), swordCommandFinal)))
			SwitchSword ();

		else if (haveSword && Input.GetKeyDown ((KeyCode)System.Enum.Parse (typeof(KeyCode), attackCommandFinal)) && timer2 > 0.5) 
        {
			timer = 0;
            timer2 = 0;
            anim.SetBool("isAttacking", true);
		} 
        else if (haveTromblon && Input.GetKey ((KeyCode)System.Enum.Parse (typeof(KeyCode), attackCommandFinal))) //IDEM
        {
            if (poulet && timer2 > 0.25)
            {
                attacks.shootPoulet();
                timer2 = 0;
            }
            else if(cochon && timer2 > 0.75)
            {
                attacks.shootCochon();
                timer2 = 0;
            }
            else if (timer2 > 2)
            {
                attacks.shootUnicorn();
                timer2 = 0;
            }
		}
        else if (haveSword && Input.GetKeyDown ((KeyCode)System.Enum.Parse (typeof(KeyCode), firstAbilityFinal)) && timer2 > 0.5)
        {
			timer = 0;
            timer2 = 0;
			StartCoroutine(attacks.dash (0.2f));
		} 
        else if (haveTromblon && Input.GetKeyDown ((KeyCode)System.Enum.Parse (typeof(KeyCode), firstAbilityFinal)) && energy.currentEnergy == energy.stratingEnergy) 
        {
            energy.currentEnergy = 0;
            if(poulet)
            {
                poulet = false;
                cochon = true;
            }
            else if(cochon)
            {
                cochon = false;
            }
            else
            {
                poulet = true;
            }
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

    void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
    {
        Vector3 syncPosition = Vector3.zero;
        if (stream.isWriting)
        {
            syncPosition = rigidbody.position;
            stream.Serialize(ref syncPosition);
        }
        else
        {
            stream.Serialize(ref syncPosition);

            syncTime = 0f;
            syncDelay = Time.time - lastSynchronizationTime;
            lastSynchronizationTime = Time.time;

            syncStartPosition = rigidbody.position;
            syncEndPosition = syncPosition;
        }
    }

	/*static public void Save()
	{
		BinaryFormatter save = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/filesaved.dat");

		WorldData data = new WorldData ();
		data.world1finished = UIManagerScript.isWorld1finished;
		data.world2finished = UIManagerScript.isWorld2finished;
		data.world3finished = UIManagerScript.isWorld3finished;
		data.level = UIManagerScript.level;

		save.Serialize (file, data);
		file.Close ();
	}

	static public void Load()
	{
		if(File.Exists(Application.persistentDataPath + "/filesaved.dat"))
		{
			BinaryFormatter load = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/filesaved.dat", FileMode.Open);
			WorldData data = (WorldData)load.Deserialize(file);
			file.Close ();
		
			UIManagerScript.isWorld1finished = data.world1finished;
			UIManagerScript.isWorld2finished = data.world2finished;
			UIManagerScript.isWorld3finished = data.world3finished;
			UIManagerScript.level = data.level;
		}
	}

[Serializable]
	class WorldData
	{
		public bool world1finished;
		public bool world2finished;
		public bool world3finished;
		public string level;
	}*/

}