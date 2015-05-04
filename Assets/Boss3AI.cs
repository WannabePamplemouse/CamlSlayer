using UnityEngine;
using System.Collections;

public class Boss3AI : MonoBehaviour {

    [SerializeField]
    private float time;

    float timer = 0;

    [SerializeField]
    GameObject missile;
    [SerializeField]
    Transform position;

	// Use this for initialization
	void Start () {
        Physics2D.IgnoreLayerCollision(gameObject.layer, 20);
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer >= time)
        {
            timer = 0;
            shoot();
        }
	}

    void shoot()
    {
       Instantiate(missile, position.position, new Quaternion(0, 0, 0, 0));
    }
}
