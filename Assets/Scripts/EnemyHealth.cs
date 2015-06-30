using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
	public int startingHealth = 100;            // The amount of health the enemy starts the game with.
	public int currentHealth;     				// The current health the enemy has.

    [SerializeField] Slider HealthSlider;
	GameObject player;
	KillCount KC;
	EnemyHealth enemyHealth;

    [SerializeField] 
    private float xHearthforce;
    [SerializeField]
    private float yHearthforce;
    [SerializeField]
    CheckBoss checker;

    void Awake ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
        if(player != null)
		    KC = player.GetComponent<KillCount> ();
		currentHealth = startingHealth;
        HealthSlider.maxValue = startingHealth;
        HealthSlider.value = startingHealth;
	}

	void Update ()
	{
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
                KC = player.GetComponent<KillCount>();
        }

        if (transform.position.y < -30)
            Death();
	}
	
	public void TakeDamage (int amount)
	{
		// Reduce the current health by the amount of damage sustained.
		currentHealth -= amount;
        HealthSlider.value = currentHealth;
		// If the current health is less than or equal to zero...
		if(currentHealth <= 0)
		{
			// ... the enemy is dead.
			Death ();
		}

        if(name == "Boss Final" || name == "BossFinalMulti") // changer de partie pour le boss final
        {
            if(currentHealth < 700)
            {
                GetComponent<BossFinal>().switch_p(1);
            }
            if(currentHealth < 250)
            {
                GetComponent<BossFinal>().switch_p(2);
            }
        }
	}
	
	void Death ()
	{
        HealthSlider.enabled = false;
        GameObject hearth = GameObject.FindGameObjectWithTag("Hearth");
        System.Random rand = new System.Random();
        for (int i = rand.Next(1, 4); i > 0; i--)
        {
            GameObject created = (GameObject)Instantiate(hearth, transform.position, new Quaternion(0f, 0f, 0f, 0f));
            int a = rand.Next(1,11);
            if(a > 5) a = -a + 5;
            int b = rand.Next(1, 6);
            created.rigidbody2D.AddForce(new Vector2(xHearthforce * a, yHearthforce * b));       
        }
        
        if(name == "Boss")
        {
            UIManagerScript.isWorld1finished = true;
        }
        else if(name == "boss3")
        {
			UIManagerScript.isWorld3finished = true;
        }
        else if (name == "Boss Final")
        {
            UIManagerScript.isWorld4finished = true;
            checker.start_teleporting();
        }
        else if (name == "BossFinalMulti")
        {
            Application.LoadLevel("Menu");
        }
        else
        {
            GameObject checka = null;
            checka = GameObject.FindGameObjectWithTag("Check");

            if (checka != null)
            {
                bossCheck check = checka.GetComponent<bossCheck>();
                if (name == "Boss1")
                {
                    check.boss1 = true;
                    check.nextLevel();
                }
                else if (name == "Boss2")
                {
                    check.boss2 = true;
                    check.nextLevel();
                }
                else if (name == "Boss3")
                {
                    check.boss3 = true;
                    check.nextLevel();
                }
            }
        }

		KC.enemyKilled ++;
        Destroy(gameObject);	
	}

    public Slider getSlider()
    {
        return HealthSlider;
    }
}