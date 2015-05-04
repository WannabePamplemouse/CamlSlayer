using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BoutonLangage : MonoBehaviour {

	private Text txt;

	void Start () {
		txt = gameObject.GetComponent<Text>();
		if (ToSettingsScript.isEnglish)
			txt.text = "Resume";
		else
			txt.text = "Continuer";
	
	}
	
	// Update is called once per frame
	void Update () {
		if (ToSettingsScript.isEnglish)
			txt.text = "Resume";
		else
			txt.text = "Continuer";	
	}
}
