using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CommandBombScript : MonoBehaviour {

	static public Text commandBomb;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		commandBomb = GetComponent<Text> ();
	}
}
