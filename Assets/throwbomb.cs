using UnityEngine;
using UnitySampleAssets._2D;
using System.Collections;

public class throwbomb : MonoBehaviour {

    [SerializeField]
    private Vector2 forceBigBullet;
    private PlatformerCharacter2D dir;
    private Inventory inventory;

	// Use this for initialization
	void Start () {
        dir = GetComponentInParent<PlatformerCharacter2D>();
        inventory = GetComponentInParent<Inventory>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.Q) && inventory.canBomb())
        {
            shootBomb();
        }
	}

    private void shootBomb()
    {
        inventory.GetBombs(-1);
        GameObject spike = GameObject.FindGameObjectWithTag("Boooom");
        spike = (GameObject)Instantiate(spike, gameObject.transform.position, new Quaternion(0, 0, 0, 0));
        if (dir.facingRight)
        {
            spike.rigidbody2D.AddForce(forceBigBullet);
        }
        else
        {
            spike.rigidbody2D.AddForce(new Vector2(-forceBigBullet.x, forceBigBullet.y));
        }
    }
}
