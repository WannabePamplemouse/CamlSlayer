using UnityEngine;
using System.Collections;

public class Dialogues : MonoBehaviour {

	bool isClose;
	int Display;
	public Transform[] Diags;
	public Transform Fuckoff;

	// Use this for initialization
	void Start () {
		Display = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isClose && Input.GetKeyDown ((KeyCode)System.Enum.Parse (typeof(KeyCode), UIManagerScript.actionCommand)) && Display < Diags.Length) 
		{
			Display++;
			Diags[Display - 1].renderer.enabled = false;
			Diags[Display].renderer.enabled = true;
		}
        if(Display == Diags.Length)
        {
			Destroy(gameObject);
        }
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Player") {
			isClose = true;
			Diags [Display].renderer.enabled = true;
			Fuckoff.renderer.enabled = false;
		}
	}

	void OnTriggerExit2D (Collider2D col)
	{
		if (col.tag == "Player") {
			isClose = false;
			Diags [Display].renderer.enabled = false;
			Fuckoff.renderer.enabled = true;
		}
	}
}
