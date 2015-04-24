using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class test : MonoBehaviour {

    Text text;
    GameObject player;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player");

        text.text = "";
	}
	
	// Update is called once per frame
	void Update () {
	    if(player.transform.position.x <= -388)
        {
            text.text = "lololololo";
        }
	}
}
