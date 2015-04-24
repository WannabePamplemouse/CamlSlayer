using UnityEngine;
using System.Collections;

public class Poulet : MonoBehaviour {

    [SerializeField]
    private float time;
    [SerializeField]
    private int value;
    private float timer;

    private bool destroyable;

    // Use this for initialization
    void Start()
    {
        Physics2D.IgnoreLayerCollision(gameObject.layer, 10);
        Physics2D.IgnoreLayerCollision(gameObject.layer, gameObject.layer);
        if (GameObject.FindGameObjectsWithTag("Poulet").Length > 1)
        {
            gameObject.tag = "Poulet1";
            timer = 0;
            destroyable = true;
        }
        else
        {
            destroyable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= time && destroyable)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            coll.gameObject.GetComponent<EnemyHealth>().TakeDamage(value);
            Destroy(gameObject);
        }
    }
}
