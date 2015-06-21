using UnityEngine;
using System.Collections;

public class PanelResumeScript : MonoBehaviour {

	public void ResumeButton (GameObject panel) {
		panel.SetActive (!panel.activeSelf);
		Pauser.paused = false;
	}

	public void SaveData()
	{
		RobotControllerScript.Save ();
	}

	public void QuitMonde()
	{
		Application.LoadLevel ("Menu");
	}
}
