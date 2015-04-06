using UnityEngine;
using System.Collections;

public class UIManagerScript : MonoBehaviour {

	public Animator startButton;
	public Animator levelButton;
	public Animator settingsButton;
	public Animator exitGameButton;
	public Animator settings;
	public Animator panelLevel;


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

	public void OpenPanelLevel()
	{
		//De la meme manière que pour le menu Setings, on enlève les autres 
		startButton.SetBool ("isHidden", true);
		levelButton.SetBool ("isHidden", true);
		settingsButton.SetBool ("isHidden", true);
		exitGameButton.SetBool ("isHidden", true);

		//On fait entrer le menu de choix de level
		panelLevel.enabled = true;
		panelLevel.SetBool ("isHidden", false);
	}

	public void ClosePanelLevel()
	{
		//On ferme le menu panelLevel
		panelLevel.SetBool ("isHidden", true);

		//On ramène le menu principal avec les autres boutons
		startButton.SetBool ("isHidden", false);
		levelButton.SetBool ("isHidden", false);
		settingsButton.SetBool ("isHidden", false);
		exitGameButton.SetBool ("isHidden", false);
	}
}
