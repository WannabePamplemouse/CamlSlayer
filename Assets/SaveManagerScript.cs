using UnityEngine;
using System.Collections;
using System;
using System.IO;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManagerScript : MonoBehaviour {

	int selGridInt = 0;
	string [] selStrings;
	Sprite [] images;
	public Image pic1;
	public Text date1;
	public Image pic2;
	public Text date2;
	public Image pic3;
	public Text date3;

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
	}
	

	void Update () 
	{
		if (File.Exists (Application.persistentDataPath + "/filesaved0.dat")) 
			pic1.enabled = true;
		if (File.Exists (Application.persistentDataPath + "/filesaved1.dat"))
			pic2.enabled = true;
		if (File.Exists (Application.persistentDataPath + "/filesaved2.dat"))
			pic3.enabled = true;
		
	
	}

	void OnGUI()
	{
		selGridInt = GUI.SelectionGrid (new Rect (120, 60, 120, 365), selGridInt, selStrings, 1);

		if (GUI.Button (new Rect (450, 550, 100, 50), "Save")) 
		{
			switch (selGridInt) 
			{
				case 0:
					//Debug.Log("lel");
					Save(selGridInt);
					chooseIcon(pic1);
					date1.text = DateTime.Now.ToString();
					break;
				case 1:
					Save(selGridInt);
					pic2.sprite = images[1];
					date2.text = DateTime.Now.ToString();
					break;
				case 2:
					Debug.Log("mdrderiredelol");
					break;
			}
		}

		if (GUI.Button (new Rect (575, 550, 100, 50), "Load")) 
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

		if (GUI.Button (new Rect (700, 550, 100, 50), "Menu")) 
		{
			Application.LoadLevel("Menu");
		}
	}

	static public void Save(int i)
	{
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
		data.level = UIManagerScript.level;
		
		save.Serialize (file, data);
		file.Close ();
	}
	
	static public void Load()
	{
		if(File.Exists(Application.persistentDataPath + "/filesaved.dat"))
		{
			BinaryFormatter load = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/filesaved.dat", FileMode.Open);
			WorldData data = (WorldData)load.Deserialize(file);
			file.Close ();
			
			UIManagerScript.isWorld1finished = data.world1finished;
			UIManagerScript.isWorld2finished = data.world2finished;
			UIManagerScript.isWorld3finished = data.world3finished;
			UIManagerScript.level = data.level;
		}
	}

	private void chooseIcon(Image img)
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

	[Serializable]
	class WorldData
	{
		public bool world1finished;
		public bool world2finished;
		public bool world3finished;
		public string level;
	}
}
