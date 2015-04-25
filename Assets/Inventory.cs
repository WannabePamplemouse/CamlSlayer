using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    [SerializeField]
    private int bombs = 2;
    [SerializeField]
    Image Bombe1, Bombe2, Bombe3, keyI;

    private int maxBombs = 3;
    private bool key = false;

    void Awake()
    {
        keyI.enabled = false;

        if (bombs == 3)
        {
            Bombe1.enabled = true;
            Bombe2.enabled = true;
            Bombe3.enabled = true;
        }
        else if (bombs == 2)
        {
            Bombe3.enabled = false;
            Bombe2.enabled = true;
            Bombe1.enabled = true;
        }
        else if (bombs == 1)
        {
            Bombe3.enabled = false;
            Bombe2.enabled = false;
            Bombe1.enabled = true;
        }
        else
        {
            Bombe3.enabled = false;
            Bombe2.enabled = false;
            Bombe1.enabled = false;
        }
    }

    public void GetBombs(int amount)
    {
        bombs += amount;

        if (bombs > maxBombs) bombs = maxBombs;
        if(bombs == 3)
        {
            Bombe1.enabled = true;
            Bombe2.enabled = true;
            Bombe3.enabled = true;
        }
        else if(bombs == 2)
        {
            Bombe3.enabled = false;
            Bombe2.enabled = true;
            Bombe1.enabled = true;
        }
        else if(bombs == 1)
        {
            Bombe3.enabled = false;
            Bombe2.enabled = false;
            Bombe1.enabled = true;
        }
        else
        {
            Bombe3.enabled = false;
            Bombe2.enabled = false;
            Bombe1.enabled = false;
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
