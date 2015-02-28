using UnityEngine;
using System.Collections;

public class ChangeLanguageScript : MonoBehaviour {

	public void ChangeLanguage () {
		Application.LoadLevel ("EnglishSettingsMenu");
		ToSettingsScript.isEnglish = true;
	}
}
