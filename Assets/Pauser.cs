using UnityEngine;
using System.Collections;

public class Pauser : MonoBehaviour {

	static public bool paused;
	private GameObject panel;
	
	// Use this for initialization
	void Start () {
		paused = false;
		panel = GameObject.FindGameObjectWithTag("PausePanel");
		panel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("escape"))
			paused = !paused;
		
		if (paused) {
			Time.timeScale = 0;
			panel.SetActive (true);
		} 
		
		else {
			Time.timeScale = 1;
			panel.SetActive(false);
		}
	}
}
