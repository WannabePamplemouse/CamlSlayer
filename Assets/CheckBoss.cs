using UnityEngine;
using System.Collections;

public class CheckBoss : MonoBehaviour {

    private bool can_teleport = false;
    private float timer = 0;

	// Update is called once per frame
	void Update () {
	    if(can_teleport)
        {
            timer += Time.deltaTime;
            if(timer > 5)
            {
                can_teleport = false;
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                player.gameObject.transform.position = new Vector3(0, 0, 0);
            }
        }
	}

    public void start_teleporting()
    {
        can_teleport = true;
    }
}
