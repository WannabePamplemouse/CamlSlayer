using UnityEngine;
using System.Collections;
using System;
using System.IO;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManagerScript : MonoBehaviour {

	int selGridInt = 0;
	string [] selStrings;
    public Sprite [] images;
	public Image pic1;
	public Text date1;
	public Text userName1;
	public Image pic2;
	public Text date2;
	public Text userName2;
	public Image pic3;
	public Text date3;
	public Text userName3;


	private string loadedtime;



	void Start () 
	{
		selStrings = new string[3];
		for (int i = 0; i < selStrings.Length; i++) 
		{
			selStrings[i] = "Save " + (i + 1);
		}

		images = Resources.LoadAll<Sprite> ("Images");

		pic1 = pic1.GetComponent<Image> ();
		pic1.enabled = false;
		pic2 = pic2.GetComponent<Image> ();
		pic2.enabled = false;
		pic3 = pic3.GetComponent<Image> ();
		pic3.enabled = false;
		date1 = date1.GetComponent<Text> ();
		date2 = date2.GetComponent<Text> ();
		date3 = date3.GetComponent<Text> ();
		userName1 = userName1.GetComponent<Text> ();
		userName2 = userName2.GetComponent<Text> ();
		userName3 = userName2.GetComponent<Text> ();

		if (File.Exists (Application.persistentDataPath + "/filesaved0.dat")) 
			pic1.enabled = true;
		if (File.Exists (Application.persistentDataPath + "/filesaved1.dat"))
			pic2.enabled = true;
		if (File.Exists (Application.persistentDataPath + "/filesaved2.dat"))
			pic3.enabled = true;

		for (int i = 0; i < 3; i++) 
		{
			Load(i);
		}
	}
	

	void Update () 
	{
		if (File.Exists (Application.persistentDataPath + "/filesaved0.dat")) 
			pic1.enabled = true;
		if (File.Exists (Application.persistentDataPath + "/filesaved1.dat"))
			pic2.enabled = true;
		if (File.Exists (Application.persistentDataPath + "/filesaved2.dat"))
			pic3.enabled = true;

		Load(0);
		Load(1);
		Load(2);
			
	}

	void OnGUI()
	{
		selGridInt = GUI.SelectionGrid (new Rect (120, 60, 120, 365), selGridInt, selStrings, 1);

		if (GUI.Button (new Rect (450, 550, 100, 50), "Save")) 
		{
			switch (selGridInt) 
			{
			case 0:
				if(Save(selGridInt))
					date1.text = DateTime.Now.ToString();
				chooseIcon(pic1);
				break;
			case 1:
				Save(selGridInt);
				chooseIcon (pic2);
				date2.text = DateTime.Now.ToString();
				break;
			case 2:
				Save (selGridInt);
				chooseIcon(pic3);
				date3.text = DateTime.Now.ToString();
				break;
			}
		}

		if (GUI.Button (new Rect (575, 550, 100, 50), "Load")) 
		{
			switch (selGridInt) 
			{
			case 0:
				Load(0);
				if(UIManagerScript.level == "")
					UIManagerScript.level = "Monde1";
				Application.LoadLevel(UIManagerScript.level);
				break;
			case 1:
				Load(1);
				if(UIManagerScript.level == "")
					UIManagerScript.level = "Monde1";
				Application.LoadLevel(UIManagerScript.level);
				break;
			case 2:
				Load(2);
				if(UIManagerScript.level == "")
					UIManagerScript.level = "Monde1";
				Application.LoadLevel(UIManagerScript.level);
				break;
			}
		}

		if (GUI.Button (new Rect (700, 550, 100, 50), "Menu")) 
		{
			Application.LoadLevel("Menu");
		}
	}

	public bool Save(int i)
	{
		if (!doesExist () && !InGameCommandController.isStarted)
			return false;

		BinaryFormatter save = new BinaryFormatter ();
		FileStream file;

		if(!(File.Exists(Application.persistentDataPath + "/filesaved" + i + ".dat")))
			file = File.Create (Application.persistentDataPath + "/filesaved" + i + ".dat");
		else
			file = File.Open(Application.persistentDataPath + "/filesaved" + i + ".dat", FileMode.Open);
		
		WorldData data = new WorldData ();
		data.world1finished = UIManagerScript.isWorld1finished;
		data.world2finished = UIManagerScript.isWorld2finished;
		data.world3finished = UIManagerScript.isWorld3finished;
		data.world4finished = UIManagerScript.isWorld4finished;
		data.savedTime = DateTime.Now.ToString ();
		data.level = UIManagerScript.level;
		
		save.Serialize (file, data);
		file.Close ();

		return true;
	}
	
	public void Load(int i)
	{

		UIManagerScript.level = "";

		if(File.Exists(Application.persistentDataPath + "/filesaved" + i + ".dat"))
		{
			BinaryFormatter load = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/filesaved" + i + ".dat", FileMode.Open);
			WorldData data = (WorldData)load.Deserialize(file);
			file.Close ();
			
			UIManagerScript.isWorld1finished = data.world1finished;
			UIManagerScript.isWorld2finished = data.world2finished;
			UIManagerScript.isWorld3finished = data.world3finished;
			UIManagerScript.isWorld4finished = data.world4finished;
			loadedtime = data.savedTime;
			UIManagerScript.level = data.level;

			if(i == 0)
			{
				chooseIcon(pic1);
				userName1.text = "Game 1";
				date1.text = loadedtime;
			}

			if(i == 1)
			{
				chooseIcon(pic2);
				userName2.text = "Game 2";
				date2.text = loadedtime;
			}

			if(i == 2)
			{
				chooseIcon(pic3);
				userName3.text = "Game 3";
				date3.text = loadedtime;
			}
		}
	}

	public void chooseIcon(Image img)
	{
		if (UIManagerScript.isWorld4finished)
			img.sprite = images [3];
		else if (UIManagerScript.isWorld3finished)
			img.sprite = images [2];
		else if (UIManagerScript.isWorld2finished)
			img.sprite = images [1];
		else
			img.sprite = images [0];
	}

	public bool doesExist()
	{
		return ((File.Exists (Application.persistentDataPath + "/filesaved0.dat"))
		        && (File.Exists (Application.persistentDataPath + "/filesaved1.dat"))
		        && (File.Exists (Application.persistentDataPath + "/filesaved2.dat")));
	}
	[Serializable]
	class WorldData
	{
		public bool world1finished;
		public bool world2finished;
		public bool world3finished;
		public bool world4finished;
		public string username;
		public string level;
		public string savedTime;
	}
}
