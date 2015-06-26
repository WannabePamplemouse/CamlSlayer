using UnityEngine;
using System.Collections;

public class bossCheck : MonoBehaviour {

    public bool boss1 = false, boss2 = false, boss3 = false;

    public void nextLevel()
    {
        if(boss1 && boss2 && boss3)
        {
            UIManagerScript.isWorld2finished = true;
        }
    }
}
