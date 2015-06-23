using UnityEngine;
using System.Collections;

public class SaveManagerScript : MonoBehaviour {

	int selGridInt = 0;
	string [] selStrings;


	void Start () 
	{
		selStrings = new string[3];
		for (int i = 0; i < selStrings.Length; i++) 
		{
			selStrings[i] = "Save " + (i + 1);
		}
	}
	

	void Update () 
	{
	
	}

	void OnGUI()
	{
		selGridInt = GUI.SelectionGrid (new Rect (50, 50, 100, 100), selGridInt, selStrings, 1, GUI.skin.button.margin);
		//Debug.Log (selGridInt);

		if (GUI.Button (new Rect (500, 350, 100, 50), "Save")) 
		{
			switch (selGridInt) 
			{
				case 0:
					Debug.Log("lel");
					break;
				case 1:
					Debug.Log("lolilol");
					break;
				case 2:
					Debug.Log("mdrderiredelol");
					break;
			}
		}

		if (GUI.Button (new Rect (600, 350, 100, 50), "Load")) 
		{
			switch (selGridInt) 
			{
				case 0:
					Debug.Log("mdrjeloadle0");
					break;
				case 1:
					Debug.Log("mdrjeloadle1");
					break;
				case 2:
					Debug.Log("mdrjeloadle2");
					break;
			}
		}
	}
}
