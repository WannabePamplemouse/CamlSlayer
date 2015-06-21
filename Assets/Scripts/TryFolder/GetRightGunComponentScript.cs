using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetRightGunComponentScript : MonoBehaviour {

	private Text txt;

	void Start () 
	{
		txt = gameObject.GetComponent<Text> ();
		txt.text = UIManagerScript.gunCommand;
	}
}
