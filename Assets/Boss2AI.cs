using UnityEngine;
using System.Collections;

public class Boss2AI : MonoBehaviour {

    [SerializeField]
    private Transform target;
    [SerializeField]
    private float time, size = 1;
    [SerializeField]
    private Vector2 force;

    private bool active = false;
    private float timer;

	// Use this for initialization
	void Start () {
        timer = time;
	}
	
	// Update is called once per frame
	void Update () {
        if (target.position.x > 2200) active = true;
        if(active && timer >= time)
        {
            shoot();
        }
        else if(timer < time)
        {
            timer += Time.deltaTime;
        }
	}

    private void shoot()
    {
        timer = 0;
        GameObject spike = GameObject.FindGameObjectWithTag("Spike");
        spike = (GameObject)Instantiate(spike, gameObject.transform.position, new Quaternion(0, 0, 0, 0));
        spike.transform.localScale = new Vector3(size, size, size);
        spike.rigidbody2D.AddForce(force);
    }
}
