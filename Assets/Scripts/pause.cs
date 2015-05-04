using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class pause : MonoBehaviour {

	static public bool paused;
    public GameObject panel;

	private Image img;
	private Button [] butonArray;

	// Use this for initialization
	void Start () {
		paused = false;
		img = GetComponent<Image> ();
		butonArray = GetComponentsInChildren<Button> ();
		img.enabled = false;
		butonArray [0].enabled = false;
		butonArray [1].enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("escape"))
			paused = !paused;

		if (paused) {
			Time.timeScale = 0;
			img.enabled = true;
			butonArray [0].enabled = true;
			butonArray [1].enabled = true;
		} 

		else {
			Time.timeScale = 1;
			img.enabled = false;
			butonArray [0].enabled = false;
			butonArray [1].enabled = false;
		}
	}
}
