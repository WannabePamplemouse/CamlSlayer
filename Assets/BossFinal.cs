using UnityEngine;
using System.Collections;

public class BossFinal : MonoBehaviour 
{

    bool p1 = false, p2 = false, p3 = false;
    EnemyHealth health;
    float timer = 0;

    [SerializeField]
    SawBlade sb1, sb2; // à voir pour le nombre
    [SerializeField]
    GameObject missile;
    [SerializeField]
    int mDamage;

	// Use this for initialization
	void Start () 
    {
        health = GetComponent<EnemyHealth>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	    //verifier la pos du joueur pour commencer quand il arrive.
        //verifier la vie du boss pour passer à p2 et à p3
        if(p1 && health.currentHealth < 100)
        {
            Destroy(sb1);
            Destroy(sb2);
            p1 = false;
            p2 = true;
        }
        if(p2)
        {
            if(health.currentHealth < 50)
            {
                p2 = false;
                p3 = true;
            }
            else
            {
                if(timer > 1)
                {
                    timer = 0;
                    shoot_missile();
                }
                else
                {
                    timer += Time.deltaTime;
                }
            }
        }
	}

    void shoot_missile()
    {
        // soit avec addforce() soit avec ennemymove à tester
    }
}
