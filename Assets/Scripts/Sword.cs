using UnityEngine;
using System.Collections;
using UnitySampleAssets._2D;

public class Sword : MonoBehaviour
{

    [SerializeField]
    private float MaxDistance;
    [SerializeField]
    private int attackDamage;
    [SerializeField]
    private int attackEnergyCost;
    [SerializeField]
    private int dashEnergyCost;
    [SerializeField]
    private float dashSpeed;
    [SerializeField]
    private float dashDuration;

    public int damageOnCollision = 0;
    public bool doDamageOnHit;

    PlatformerCharacter2D dir;
    float timer;
    PlayerEnergy energy;
    Rigidbody2D player;
    PlayerH playerHealth;
    EnemyHealth enemyHealth;
    GameObject enemy;

    public bool canDash;

    void Awake()
    {
        player = GetComponentInParent<Rigidbody2D>();
        dir = GetComponentInParent<PlatformerCharacter2D>();
        energy = GetComponentInParent<PlayerEnergy>();
        playerHealth = GetComponentInParent<PlayerH>();
        renderer.enabled = false;
        timer = 0;
        canDash = true;
        doDamageOnHit = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer != 0)
        {
            timer += Time.deltaTime;
            if (timer > 1.25)
            {
                timer = 0;
                renderer.enabled = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            attack();
        }
        else if (Input.GetKeyDown(KeyCode.Z) && canDash)
        {
            StartCoroutine(dash(dashDuration));
        }
    }


    private void attack()
    {

        if (energy.currentEnergy >= attackEnergyCost)
        {
            energy.UseEnergy(attackEnergyCost);

            renderer.enabled = true;
            timer = 1;

            RaycastHit2D hit;

            if (dir.facingRight)
                hit = Physics2D.Raycast(transform.position, Vector2.right, MaxDistance);
            else
                hit = Physics2D.Raycast(transform.position, -Vector2.right, MaxDistance);


            if (hit.collider != null && hit.transform.gameObject.tag == "Enemy")
            {
                GameObject enemy = hit.transform.gameObject;
                EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
                enemyHealth.TakeDamage(attackDamage);
            }
        }
    }

    IEnumerator dash(float dur)
    {
        if (energy.currentEnergy >= dashEnergyCost)
        {
            Physics2D.IgnoreLayerCollision(9, gameObject.layer);
            doDamageOnHit = true;
            playerHealth.canTakeDamage = false;
            damageOnCollision = 50;
            canDash = false;
            float time = 0;

            energy.UseEnergy(dashEnergyCost);

            float realDashSpeed;
            if (dir.facingRight)
                realDashSpeed = dashSpeed;
            else
                realDashSpeed = -dashSpeed;

            while (time < dur)
            {
                time += Time.deltaTime;
                player.velocity = new Vector2(realDashSpeed, 0);
                yield return 0;
            }

            doDamageOnHit = false;
            playerHealth.canTakeDamage = true;
            canDash = true;
            damageOnCollision = 0;
            Physics2D.IgnoreLayerCollision(9, gameObject.layer, false);
        }
    }
}
