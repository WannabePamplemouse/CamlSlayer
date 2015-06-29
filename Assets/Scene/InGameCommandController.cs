using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class InGameCommandController : MonoBehaviour {

	private string bombCommand;
	private string swordCommand;
	private string gunCommand;
	private string attackCommand;
	private string firstAbility;
	private string actionCommand;

	private GameObject commandPanel;

	private GameObject buton1;
	private GameObject buton2;
	private GameObject buton3;
	private GameObject buton4;
	private List<GameObject> butons;

	static public float defaultValue = 0.2f;
	Slider volumeSlider;
	static public float volumeValue;
	static public bool isAvailable;
	GameObject temp;

	static public bool isStarted = false;

	void Start () 
	{
		this.bombCommand = UIManagerScript.bombCommand;
		this.swordCommand = UIManagerScript.swordCommand;
		this.gunCommand = UIManagerScript.gunCommand;
		this.firstAbility = UIManagerScript.firstAbility;
		this.attackCommand = UIManagerScript.attackCommand;
		this.actionCommand = UIManagerScript.actionCommand;

		commandPanel = GameObject.FindGameObjectWithTag ("CommandPanel");
		commandPanel.SetActive (false);

		butons = new List<GameObject> ();

		isStarted = true;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		UIManagerScript.bombCommand = this.bombCommand;
		UIManagerScript.swordCommand = this.swordCommand;
		UIManagerScript.gunCommand = this.gunCommand;
		UIManagerScript.firstAbility = this.firstAbility;
		UIManagerScript.attackCommand = this.attackCommand;
		UIManagerScript.actionCommand = this.actionCommand;
	
	}

	public void GetCommandBomb(GameObject InputBomb)
	{
		InputField bomb = InputBomb.GetComponent<InputField>();
		bombCommand = bomb.textComponent.text;
		if (bombCommand == "")
			bombCommand = "B";
	}
	
	public void GetCommandSword(GameObject InputSword)
	{
		InputField sword = InputSword.GetComponent<InputField> ();
		swordCommand = sword.textComponent.text;
		if (swordCommand == "")
			swordCommand = "E";
	}
	
	public void GetCommandGun(GameObject InputGun)
	{
		InputField gun = InputGun.GetComponent<InputField> ();
		gunCommand = gun.textComponent.text;
		if (gunCommand == "")
			gunCommand = "G";
	}
	
	public void GetCommandAttack(GameObject InputAttack)
	{
		InputField attack = InputAttack.GetComponent<InputField> ();
		attackCommand = attack.textComponent.text;
		if (attackCommand == "")
			attackCommand = "Q";
	}
	
	public void GetCommandFirstAbility (GameObject InputFirstAbitily)
	{
		InputField ability = InputFirstAbitily.GetComponent<InputField> ();
		firstAbility = ability.textComponent.text;
		if (firstAbility == "")
			firstAbility = "S";
	}

	public void GetcommandCommand(GameObject InputCommand)
	{
		InputField command = InputCommand.GetComponent<InputField> ();
		actionCommand = command.textComponent.text;
		if (actionCommand == "")
			actionCommand = "F";
	}

	public void OpenPanelCommand(GameObject mainPanel)
	{
		/*mainPanel.SetActive (false);
		commandPanel.SetActive (!commandPanel.activeSelf);*/

		/*commandAnimator.enabled = true;
		commandAnimator.SetBool ("opening", true);*/
		/*Button[] butons = mainPanel.GetComponents<Button> ();
		foreach (Button bouton in butons) 
		{
			Image imag = bouton.GetComponent<Image>();
			Color newcol = new Color(imag.color.r, imag.color.g, imag.color.b, 0);
			imag.color = newcol;
		}
		Image img = mainPanel.GetComponent<Image> ();
		Color newPanCol = new Color (img.color.r, img.color.g, img.color.b, 0);
		img.color = newPanCol;*/

		buton1 = GameObject.FindGameObjectWithTag ("ResumeButton");
		buton2 = GameObject.FindGameObjectWithTag ("SaveButton");
		buton3 = GameObject.FindGameObjectWithTag ("CommandButton");
		buton4 = GameObject.FindGameObjectWithTag ("QuitButton");

		butons.Add (buton1);
		butons.Add (buton2);
		butons.Add (buton3);
		butons.Add (buton4);

		foreach (GameObject bouton in butons) 
		{
			Image imag = bouton.GetComponent<Image>();
			Color newcol = new Color(imag.color.r, imag.color.g, imag.color.b, 0);
			imag.color = newcol;
		}

		commandPanel.SetActive (!commandPanel.activeSelf);

		if (temp == null) 
		{		
			temp = GameObject.Find ("Volume Slider");
			if (temp != null) 
			{
				volumeSlider = temp.GetComponent<Slider> ();
				if (volumeSlider != null)
					volumeSlider.normalizedValue = PlayerPrefs.HasKey ("VolumeLevel") ? PlayerPrefs.GetFloat ("VolumeLevel") : defaultValue;
			}
		}

		isAvailable = true;
		volumeValue = volumeSlider.normalizedValue;
	}

	public void ClosePanelCommand()
	{
		commandPanel.SetActive (!commandPanel.activeSelf);

		foreach (GameObject bouton in butons) 
		{
			Image imag = bouton.GetComponent<Image>();
			Color newcol = new Color(imag.color.r, imag.color.g, imag.color.b, 255);
			imag.color = newcol;
		}

		isAvailable = false;
	}

	public void onValueChanged()
	{
		volumeValue = volumeSlider.normalizedValue;
	}
}
