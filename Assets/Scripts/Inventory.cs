using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    [SerializeField]
    public int bombs = 2;
    [SerializeField]
    public Image Bombe1, Bombe2, Bombe3, Bombe4, Bombe5, keyI;

    private int maxBombs = 3;
    public bool key = false;

    void Awake()
    {
        if(UIManagerScript.isWorld2finished)
        {
            maxBombs = 5;
        }

        keyI.enabled = false;

        checkBomb();
    }

    public void GetBombs(int amount)
    {
        bombs += amount;

        if (bombs > maxBombs) bombs = maxBombs;

        checkBomb();
    }

    void checkBomb()
    {
        if (bombs == 5)
        {
            Bombe1.enabled = true;
            Bombe2.enabled = true;
            Bombe3.enabled = true;
            Bombe4.enabled = true;
            Bombe5.enabled = true;
        }
        else if (bombs == 4)
        {
            Bombe1.enabled = true;
            Bombe2.enabled = true;
            Bombe3.enabled = true;
            Bombe4.enabled = true;
            Bombe5.enabled = false;
        }
        else if (bombs == 3)
        {
            Bombe1.enabled = true;
            Bombe2.enabled = true;
            Bombe3.enabled = true;
            Bombe4.enabled = false;
            Bombe5.enabled = false;
        }
        else if (bombs == 2)
        {
            Bombe3.enabled = false;
            Bombe2.enabled = true;
            Bombe1.enabled = true;
            Bombe4.enabled = false;
            Bombe5.enabled = false;
        }
        else if (bombs == 1)
        {
            Bombe3.enabled = false;
            Bombe2.enabled = false;
            Bombe1.enabled = true;
            Bombe4.enabled = false;
            Bombe5.enabled = false;
        }
        else
        {
            Bombe3.enabled = false;
            Bombe2.enabled = false;
            Bombe1.enabled = false;
            Bombe4.enabled = false;
            Bombe5.enabled = false;
        }
    }

    public void GetKey()
    {
        keyI.enabled = true;
        key = true;
    }

    public bool canBomb()
    {
        return bombs > 0;
    }

    public bool haveKey()
    {
        return key;
    }
}
