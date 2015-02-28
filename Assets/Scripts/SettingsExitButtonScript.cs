using UnityEngine;
using System.Collections;

public class SettingsExitButtonScript : MonoBehaviour {

	public void LoadMenu () {

		if (ToSettingsScript.isEnglish)
			Application.LoadLevel ("Project_menu");
		else
			Application.LoadLevel ("French_menu");
	}
}
