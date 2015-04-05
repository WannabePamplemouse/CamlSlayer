using UnityEngine;
using System.Collections;

public class UIManagerScript : MonoBehaviour {

	public Animator startButton;
	public Animator levelButton;
	public Animator settingsButton;
	public Animator exitGameButton;
	public Animator settings;


	public void OpenSettings()
	{
		//Pour ouvrir le menu Settings, on enlève de l'écran tous les boutons
		startButton.SetBool ("isHidden", true);
		levelButton.SetBool ("isHidden", true);
		settingsButton.SetBool ("isHidden", true);
		exitGameButton.SetBool ("isHidden", true);

		//On fait entrer le menu Settings
		settings.enabled = true;
		settings.SetBool ("isHidden", false);
	}


	public void CloseSettings()
	{
		//On ferme le menu Settings
		settings.SetBool ("isHidden", true);

		//On ramène tous les autres boutons
		startButton.SetBool ("isHidden", false);
		levelButton.SetBool ("isHidden", false);
		settingsButton.SetBool ("isHidden", false);
		exitGameButton.SetBool ("isHidden", false);
	}
}
