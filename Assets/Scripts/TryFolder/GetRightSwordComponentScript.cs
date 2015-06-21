using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetRightSwordComponentScript : MonoBehaviour {
	
	private Text txt;

	void Start () 
	{
		txt = gameObject.GetComponent<Text> ();
		txt.text = UIManagerScript.swordCommand;
	}
}
