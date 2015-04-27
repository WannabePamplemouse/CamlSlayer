using UnityEngine;
using System.Collections;

public class spikeBall : MonoBehaviour {

    [SerializeField]
    private float time;
    [SerializeField]
    private int value;
    private float timer;

    private bool destroyable;

    // Use this for initialization
    void Start()
    {
        Physics2D.IgnoreLayerCollision(gameObject.layer, 8);
        Physics2D.IgnoreLayerCollision(gameObject.layer, gameObject.layer);
        Physics2D.IgnoreLayerCollision(gameObject.layer, 14);
        if (GameObject.FindGameObjectsWithTag("Spike").Length > 1)
        {
            gameObject.tag = "Spike1";
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
        if (coll.gameObject.tag == "Player")
        {
            coll.gameObject.GetComponent<PlayerH>().TakeDamage(value);
            Destroy(gameObject);
        }
    }
}
