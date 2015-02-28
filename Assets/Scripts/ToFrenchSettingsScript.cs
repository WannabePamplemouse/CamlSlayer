using UnityEngine;
using System.Collections;

public class ToFrenchSettingsScript : MonoBehaviour {

	public void ToFrenchSettings() {
		Application.LoadLevel ("SettingsScenes");
		ToSettingsScript.isEnglish = false;
	}
}
