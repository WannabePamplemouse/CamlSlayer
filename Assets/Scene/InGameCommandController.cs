using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class InGameCommandController : MonoBehaviour {

	private string bombCommand;
	private string swordCommand;
	private string gunCommand;
	private string attackCommand;
	private string firstAbility;
	private string actionCommand;

	private GameObject commandPanel;
	private EventSystem es;
	public Animator commandAnimator;

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

		es = EventSystem.current;
	
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
		Button[] butons = mainPanel.GetComponents<Button> ();
		foreach (Button bouton in butons) 
		{
			Image imag = bouton.GetComponent<Image>();
			Color newcol = new Color(imag.color.r, imag.color.g, imag.color.b, 0);
			imag.color = newcol;
		}
		Image img = mainPanel.GetComponent<Image> ();
		Color newPanCol = new Color (img.color.r, img.color.g, img.color.b, 0);
		img.color = newPanCol;

		commandPanel.SetActive (!commandPanel.activeSelf);

	}

	public void ClosePanelCommand()
	{
		commandPanel.SetActive (!commandPanel.activeSelf);
		commandAnimator.SetBool ("opening", false);
	}
}
