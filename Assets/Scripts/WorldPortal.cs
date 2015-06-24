using UnityEngine;
using System.Collections;

public class WorldPortal : MonoBehaviour {
    [SerializeField]
    private int worldindex; //World the player is currently in. Don't forget to assign it.
	


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
                if(UIManagerScript.isWorld4finished)
                    particleSystem.enableEmission = true;
                break;
            default:
                //Not supposed to happen, still does nothing.
                break;
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        switch(worldindex)
        {
            case 1:
                if(UIManagerScript.isWorld1finished && col.tag == "Player")
                {
                    UIManagerScript.level = "Monde2";
                    Application.LoadLevel("Monde2");
                }
                break;
            case 2:
                if (UIManagerScript.isWorld2finished && col.tag == "Player")
                {
                    UIManagerScript.level = "Monde3";
                    Application.LoadLevel("Monde3");
                }
                break;
            case 3:
                if (UIManagerScript.isWorld3finished && col.tag == "Player")
                {
                    UIManagerScript.level = "Monde4";
                    Application.LoadLevel("Monde4");
                }
                break;
            case 4:
                if (UIManagerScript.isWorld4finished && col.tag == "Player")
                {
                    UIManagerScript.level = "Credits";
                    Application.LoadLevel("Credits");
                }
                break;
            default:
                //Not supposed to happen.
                break;
        }
    }
}
