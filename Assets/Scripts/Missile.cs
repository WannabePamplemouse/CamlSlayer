using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {

    [SerializeField]
    private float time;

    [SerializeField]
    private int value;
    private float timer;

    [SerializeField]
    public GameObject PartExpl;
    [SerializeField]
    public GameObject PartExpl2;

	// Use this for initialization
	void Start () {
        Physics2D.IgnoreLayerCollision(gameObject.layer, 14);
        Physics2D.IgnoreLayerCollision(gameObject.layer, gameObject.layer);
        Physics2D.IgnoreLayerCollision(gameObject.layer, 17);
        Physics2D.IgnoreLayerCollision(gameObject.layer, 15);
        Physics2D.IgnoreLayerCollision(gameObject.layer, 16);
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            coll.gameObject.GetComponent<PlayerH>().TakeDamage(value);
        }

        gameObject.collider2D.enabled = false;
        gameObject.rigidbody2D.gravityScale = 0;
        gameObject.rigidbody2D.velocity = new Vector2(0, 0);
        GetComponent<AudioSource>().Play();
        gameObject.rigidbody2D.fixedAngle = true;
        PartExpl.SetActive(true);
        PartExpl2.SetActive(true);
        renderer.enabled = false;
        Destroy(gameObject, 2);
    }
}
