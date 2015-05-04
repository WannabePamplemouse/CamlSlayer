using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LangageText : MonoBehaviour {

	private Text txt;

	void Start () {
		txt = gameObject.GetComponent<Text> ();
		if (ToSettingsScript.isEnglish)
			txt.text = "Quit";
		else
			txt.text = "Quitter"; 
	}
	
	// Update is called once per frame
	void Update () {
		if (ToSettingsScript.isEnglish)
			txt.text = "Quit";
		else
			txt.text = "Quitter";
	
	}
}
