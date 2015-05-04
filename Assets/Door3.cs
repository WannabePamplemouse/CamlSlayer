using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Door3 : MonoBehaviour {

    public Transform target;
    public int enemiesToKill;

    GameObject player;
    KillCount KC;
    GameObject portal;
    Inventory inv;
    Camera camera;

    [SerializeField]
    Text text;

    void Awake()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        player = GameObject.FindGameObjectWithTag("Player");
        KC = player.GetComponent<KillCount>();
        inv = player.GetComponent<Inventory>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && KC.enemyKilled >= enemiesToKill && inv.key)
        {
            other.gameObject.transform.position = target.transform.position;
            camera.orthographicSize = 14;
            text.text = "Press N near turrets to fire a bomb";
        }
    }
}
