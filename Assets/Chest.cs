using UnityEngine;
using System.Collections;

public class Chest : MonoBehaviour {

    [SerializeField]
    private GameObject openChest;
    [SerializeField]
    private int bombs;
    [SerializeField]
    private bool key;
	[SerializeField]
	private GameObject effect;

    void Awake()
    {
        openChest.renderer.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            openChest.renderer.enabled = true;
            collect(coll.gameObject.GetComponent<Inventory>());
			effect.SetActive(true);
            Destroy(gameObject);
        }
    }

    void collect(Inventory inventory)
    {
        inventory.GetBombs(bombs);
        if (key) inventory.GetKey();
    }
}
