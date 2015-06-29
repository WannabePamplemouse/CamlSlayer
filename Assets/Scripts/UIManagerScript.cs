using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour {

	public Animator startButton;
	public Animator levelButton;
	public Animator settingsButton;
	public Animator exitGameButton;
	public Animator multiButton;
	public Animator loadButton;
	public Animator settings;
	public Animator panelLevel;
	public Animator commandLevel;

	static public string level = "Monde1";
    
	public Button World2;
	public Button World3;
	public Button World4;
			
	static public string bombCommand = "B";
	static public string swordCommand = "E";
	static public string gunCommand = "G";
	static public string attackCommand = "Q";
	static public string firstAbility = "S";
	static public string actionCommand = "F";

	static public bool isWorld1finished = false;
	static public bool isWorld2finished = false;
	static public bool isWorld3finished = false;
    static public bool isWorld4finished = false;

	static public float defaultValue = 0.2f;
	Slider volumeSlider;
	static public float volumeValue;

	void Start()
	{
		GameObject temp = GameObject.Find ("Volume Slider");
		if (temp != null) 
		{
			volumeSlider = temp.GetComponent<Slider> ();
			if(volumeSlider != null)
				volumeSlider.normalizedValue = PlayerPrefs.HasKey("VolumeLevel") ? PlayerPrefs.GetFloat("VolumeLevel") : defaultValue;
		}

		volumeValue = volumeSlider.normalizedValue;
	}
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.A))
			isWorld1finished = true;

		if(isWorld1finished)
			World2.interactable = true;
		if (isWorld2finished)
			World3.interactable = true;
		if (isWorld3finished)
			World4.interactable = true;
	}


	public void OpenSettings()
	{
		//Pour ouvrir le menu Settings, on enlève de l'écran tous les boutons
		startButton.SetBool ("isHidden", true);
		levelButton.SetBool ("isHidden", true);
		settingsButton.SetBool ("isHidden", true);
		exitGameButton.SetBool ("isHidden", true);
		multiButton.SetBool ("isHidden", true);
		loadButton.SetBool ("isHidden", true);

		//On fait entrer le menu Settings
		settings.enabled = true;
		settings.SetBool ("isHidden", false);
	}


	public void CloseSettings()
	{
		//On ferme le menu Settings et le menu command
		settings.SetBool ("isHidden", true);
		settings.SetBool ("Shownable", false);
		commandLevel.SetBool ("isHidden", true);

		//On ramène tous les autres boutons
		startButton.SetBool ("isHidden", false);
		levelButton.SetBool ("isHidden", false);
		settingsButton.SetBool ("isHidden", false);
		exitGameButton.SetBool ("isHidden", false);
		multiButton.SetBool ("isHidden", false);
		loadButton.SetBool ("isHidden", false);
	}

	public void OpenPanelLevel()
	{
		//De la meme manière que pour le menu Setings, on enlève les autres 
		startButton.SetBool ("isHidden", true);
		levelButton.SetBool ("isHidden", true);
		settingsButton.SetBool ("isHidden", true);
		exitGameButton.SetBool ("isHidden", true);
		multiButton.SetBool ("isHidden", true);
		loadButton.SetBool ("isHidden", true);

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
		multiButton.SetBool ("isHidden", false);
		loadButton.SetBool ("isHidden", false);
	}

	public void OpenCommandPanel()
	{
		settings.SetBool ("Shownable", true);
		commandLevel.enabled = true;
		commandLevel.SetBool ("isHidden", false);
	}

	public void CloseCommandPanel()
	{
		settings.SetBool ("Shownable", false);
		commandLevel.SetBool ("isHidden", true);
	}

	public void ChangeLevel1()
	{
		level = "Monde1";
		Application.LoadLevel (level);
	}

	public void ChangeLevel2 ()
	{
		level = "Monde2";
		Application.LoadLevel (level);
	}

	public void ChangeLevel3()
	{
		level = "Monde3";
		Application.LoadLevel (level);
	}

	public void ChangeLevel4()
	{
		level = "Monde4";
		Application.LoadLevel (level);
	}

	public void ChangeLevel5()
	{
		level = "Monde5";
		Application.LoadLevel (level);
	}

	public void LoadLevel()
	{

		Application.LoadLevel (level);
	}

	public void GetCommandBomb(GameObject InputBomb)
	{
		InputField bomb = InputBomb.GetComponent<InputField>();
		bombCommand = bomb.textComponent.text;
	}

	public void GetCommandSword(GameObject InputSword)
	{
		InputField sword = InputSword.GetComponent<InputField> ();
		swordCommand = sword.textComponent.text;
	}

	public void GetCommandGun(GameObject InputGun)
	{
		InputField gun = InputGun.GetComponent<InputField> ();
		gunCommand = gun.textComponent.text;
	}

	public void GetCommandAttack(GameObject InputAttack)
	{
		InputField attack = InputAttack.GetComponent<InputField> ();
		attackCommand = attack.textComponent.text;
	}

	public void GetCommandFirstAbility (GameObject InputFirstAbitily)
	{
		InputField ability = InputFirstAbitily.GetComponent<InputField> ();
		firstAbility = ability.textComponent.text;
	}
	
	public void QuitGame()
	{
		Application.Quit ();
	}

	public void LoadFile()
	{
		Application.LoadLevel ("SaveScene");
	}

    public void Multi()
    {
        Application.LoadLevel("Multi");
    }

	public void onValueChanged()
	{
		volumeValue = volumeSlider.normalizedValue;
	}
}
