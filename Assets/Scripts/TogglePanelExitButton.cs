using UnityEngine;
using System.Collections;

public class TogglePanelExitButton : MonoBehaviour {

	public void TogglePanel (GameObject panel){
		panel.SetActive (!panel.activeSelf);
	}
}
