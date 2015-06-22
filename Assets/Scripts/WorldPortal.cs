using UnityEngine;
using System.Collections;

public class WorldPortal : MonoBehaviour {
    private int worldindex; //World the player is currently in. Don't forget to assign it.
	
    void Start()
    {
        switch (UIManagerScript.level)
        {
            case "Monde2":
                worldindex = 2;
                break;
            case "Monde3":
                worldindex = 3;
                break;
            case "Monde4":
                worldindex = 4;
                break;
            default:
                worldindex = 1;
                break;
        }
    }

	void Update () {
	    switch(worldindex)
        {
            case 1:
                if(UIManagerScript.isWorld1finished)
                {
                    particleSystem.enableEmission = true;
                }
                break;
            case 2:
                if(UIManagerScript.isWorld2finished)
                {
                    particleSystem.enableEmission = true;
                }
                break;
            case 3:
                if(UIManagerScript.isWorld3finished)
                {
                    particleSystem.enableEmission = true;
                }
                break;
            case 4:
                //TO DO : Add the extra credits or back to the menu when the world 4 is finished.
                break;
            default:
                //Not supposed to happen, still does nothing.
                break;
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(UIManagerScript.isWorld4finished && col.tag == "Player")
        {
            Application.LoadLevel("Credits");
        }
        else if(UIManagerScript.isWorld3finished && col.tag == "Player")
        {
            UIManagerScript.level = "Monde4";
            Application.LoadLevel("Monde4");
        }
        else if (UIManagerScript.isWorld2finished && col.tag == "Player")
        {
            UIManagerScript.level = "Monde3";
            Application.LoadLevel("Monde3");
        }
        else if(UIManagerScript.isWorld1finished && col.tag == "Player")
        {
            UIManagerScript.level = "Monde2";
            Application.LoadLevel("Monde2");
        }
    }
}
