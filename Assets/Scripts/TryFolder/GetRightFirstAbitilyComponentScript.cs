using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetRightFirstAbitilyComponentScript : MonoBehaviour {

	private Text txt;

	void Start () 
	{
		txt = gameObject.GetComponent<Text> ();
		txt.text = UIManagerScript.firstAbility;
	}
}
