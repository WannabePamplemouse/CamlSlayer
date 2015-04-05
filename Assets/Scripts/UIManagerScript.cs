using UnityEngine;
using System.Collections;

public class UIManagerScript : MonoBehaviour {

	public Animator starButton;
	public Animator settingsButton;
	public Animator levelButton;
	public Animator exitGameButton;
	public Animator settings;


	public void OpenSettings()
	{
		//Pour faire entrer le menu Settings, on enlève tous les autres boutons
		starButton.SetBool ("isHidden", true);
		settingsButton.SetBool ("isHidden", true);
		levelButton.SetBool ("isHidden", true);
		exitGameButton.SetBool ("isHidden", true);

		//La fameuse entrée de ce menu
		settings.enabled = true;
		settings.SetBool ("isHidden", false);
	}

	public void CloseSettings()
	{
		//Pour fermer le menu Settings et faire réapparaitre les autres boutons.
		starButton.SetBool ("isHidden", false);
		settingsButton.SetBool ("isHidden", false);
		levelButton.SetBool ("isHidden", false);
		exitGameButton.SetBool ("isHidden", false);

		settings.SetBool ("isHidden", true);
	}
}
