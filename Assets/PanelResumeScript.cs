using UnityEngine;
using System.Collections;

public class PanelResumeScript : MonoBehaviour {

	public void ResumeButton (GameObject panel) {
		panel.SetActive (!panel.activeSelf);
		pause.paused = false;
	}
}
