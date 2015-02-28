using UnityEngine;
using System.Collections;

public class ToSettingsScript : MonoBehaviour {

	static public bool isEnglish = true;

	public void LoadSettings () {
		Application.LoadLevel ("EnglishSettingsMenu");
	}
}
