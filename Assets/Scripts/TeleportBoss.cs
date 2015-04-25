using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TeleportBoss : MonoBehaviour {

    [SerializeField]
    private Text infoText;

    public Transform target;
    public int enemiesToKill;
    public bool teleported;

    private float timer = 6;

    GameObject player;
    KillCount KC;
    GameObject portal;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        KC = player.GetComponent<KillCount>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && KC.enemyKilled >= enemiesToKill && !teleported)
        {
            if (other.GetComponent<Inventory>().haveKey())
            {
                other.gameObject.transform.position = target.transform.position;
                target.GetComponent<Teleport>().teleported = true;
            }
            else
            {
                infoText.text = "You need to find the key to pass that door !";
                timer = 0;
            }
        }
    }

    void Update()
    {
        if(timer <= 5)
        {
            timer += Time.deltaTime;
        }
        else
        {
            infoText.text = "";
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            teleported = false;
        }
    }
}
