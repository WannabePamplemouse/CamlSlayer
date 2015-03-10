using UnityEngine;
using System.Collections;

public class PanelToMenu : MonoBehaviour {

	public void BackToMenu () {
		if (ToSettingsScript.isEnglish)
			Application.LoadLevel ("Project_menu");
		else
			Application.LoadLevel ("French_menu");
	}
}
