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


	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		KC = player.GetComponent<KillCount> ();
		currentHealth = startingHealth;
        HealthSlider.maxValue = startingHealth;
        HealthSlider.value = startingHealth;
	}

	void Update ()
	{
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
            UIManagerScript.World2.interactable = true;
            StartCoroutine(wait());
            Application.LoadLevel("Monde2");
        }
        else
        {
            GameObject checka = GameObject.FindGameObjectWithTag("check"); ;
            bossCheck check = checka.GetComponent<bossCheck>();
            if(name == "boss1")
            {
                check.boss1 = true;
                check.nextLevel();
            }
            else if(name == "boss2")
            {
                check.boss2 = true;
                check.nextLevel();
            }
            else if (name == "boss3")
            {
                check.boss3 = true;
                check.nextLevel();
            }
        }

		KC.enemyKilled ++;
        Destroy(gameObject);	
	}

    static public IEnumerator wait()
    {
        yield return new WaitForSeconds(5);
    }

    public Slider getSlider()
    {
        return HealthSlider;
    }
}