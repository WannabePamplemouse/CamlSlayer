using UnityEngine;
using System.Collections;

public class pause : MonoBehaviour {

	private bool paused;

	// Use this for initialization
	void Start () {
		paused = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("escape"))
			paused = !paused;
		if (paused)
			Time.timeScale = 0;
		else
			Time.timeScale = 1;
	}
}
