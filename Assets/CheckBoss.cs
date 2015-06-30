using UnityEngine;
using System.Collections;

public class CheckBoss : MonoBehaviour {

    private bool can_teleport = false;
    private float timer = 0;

    [SerializeField]
    Camera cam;

    void Start()
    {
        can_teleport = false;
    }

	// Update is called once per frame
	void Update () {
	    if(can_teleport)
        {
            timer += Time.deltaTime;
            if(timer > 5)
            {
                can_teleport = false;
                cam.orthographicSize = 10;
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                player.gameObject.transform.position = new Vector3(2100, 15, 0);
            }
        }
	}

    public void start_teleporting()
    {
        can_teleport = true;
    }
}
