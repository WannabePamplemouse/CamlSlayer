using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine.UI;

public class NetworkManager2 : MonoBehaviour
{

    string registeredGameName = "WannabeePamplemousse_CamlSlayer_Multiplayer";
    bool isRefreshing = false;
    float refreshRequestLength = 3.0f;
    HostData[] hostData;

    public GameObject playerPref;
    public GameObject robotPref;
    public GameObject UIprefab;

    private GameObject Player;
    private GameObject Robot;
    private GameObject UI;
    public static bool isMulti = false;

    private float lastSynchronizationTime = 0f;
    private float syncDelay = 0f;
    private float syncTime = 0f;
    private Vector3 syncStartPosition = Vector3.zero;
    private Vector3 syncEndPosition = Vector3.zero;

    [SerializeField]
    public GameObject[] enemies;

    private GameObject[] ens = new GameObject[18];

    void Awake()
    {
        isMulti = true;
    }

    private void StartServer()
    {
        Network.InitializeServer(5, 25000, false);
        MasterServer.RegisterHost(registeredGameName, "CamlSlayer Multiplayer", "Here you can test the multiplayer !");
    }

    void OnServerInitialized()
    {
        Player = (GameObject)Network.Instantiate(playerPref, new Vector3(10f, 5f, 0f), Quaternion.identity, 0);
        UI = (GameObject)Network.Instantiate(UIprefab, new Vector3(0, 0, 0), Quaternion.identity, 0);
        Slider[] sliders = UI.GetComponentsInChildren<Slider>();
        PlayerH ph = Player.GetComponent<PlayerH>();
        PlayerEnergy eh = Player.GetComponent<PlayerEnergy>();
        if(sliders[0].name == "HealthBar")
        {
            ph.HealthSlider = sliders[0];
            eh.EnergySlider = sliders[1];
        }
        else
        {
            ph.HealthSlider = sliders[1];
            eh.EnergySlider = sliders[0];

        }
        Image[] images = UI.GetComponentsInChildren<Image>();
        Inventory inv = Player.GetComponent<Inventory>();
        inv.bombs = 2;
        inv.key = true;
        foreach(Image im in images)
        {
            if(im.name == "Bombe1")
            {
                inv.Bombe1 = im;
            }
            else if(im.name == "Bombe2")
            {
                inv.Bombe2 = im;
            }
            else if (im.name == "Bombe3")
            {
                inv.Bombe3 = im;
            }
            else if (im.name == "Bombe4")
            {
                inv.Bombe4 = im;
            }
            else if (im.name == "Bombe5")
            {
                inv.Bombe5 = im;
            }
            else if (im.name == "Key")
            {
                inv.keyI = im;
            }
        }
        inv.GetBombs(0);

        int i = 0;
        foreach(GameObject en in enemies)
        {
            ens[i] = (GameObject)Network.Instantiate(en, en.gameObject.transform.position, Quaternion.identity, 0);
            i++;
        }
    }

    void OnMasterServerEvent(MasterServerEvent masterServerEvent)
    {
        if (masterServerEvent == MasterServerEvent.RegistrationSucceeded)
            Debug.Log("Registration successfull !");
    }

    public IEnumerator RefreshHostList()
    {
        MasterServer.RequestHostList(registeredGameName);
        float timeStarted = Time.time;
        float timeEnd = Time.time + refreshRequestLength;

        while (Time.time < timeEnd)
        {
            hostData = MasterServer.PollHostList();
            yield return new WaitForEndOfFrame();
        }
    }

    private void JoinServer(HostData hostData)
    {
        Network.Connect(hostData);
    }

    void OnConnectedToServer()
    {
        Robot = (GameObject)Network.Instantiate(robotPref, new Vector3(0f, 10f, -100f), Quaternion.identity, 0);
    }

    void OnPlayerDisconnected(NetworkPlayer player)
    {
        Network.DestroyPlayerObjects(player);
    }

    void OnApplicationQuit()
    {
        if (Network.isServer)
        {
            Network.Disconnect(200);
            MasterServer.UnregisterHost();
        }

        if (Network.isClient)
            Network.Disconnect(200);

    }

	/*void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
	{
		Vector3 syncPosition = Vector3.zero;
		Vector3 syncVelocity = Vector3.zero;
		if (stream.isWriting) {
			syncPosition = rigidbody.position;
			stream.Serialize (ref syncPosition);
			
			syncVelocity = rigidbody.velocity;
			stream.Serialize (ref syncVelocity);
		} 
		else {
			stream.Serialize(ref syncPosition);
			stream.Serialize(ref syncVelocity);
			
			syncTime = 0f;
			syncDelay = Time.time - lastSynchronizationTime;
			lastSynchronizationTime = Time.time;
			
			syncEndPosition = syncPosition + syncVelocity * syncDelay;
			syncStartPosition = rigidbody.position;
		}
	}

	private void SyncedMovement()
	{
		syncTime += Time.deltaTime;
		rigidbody.position = Vector3.Lerp (syncStartPosition, syncEndPosition, syncTime / syncDelay);
	}

    void Update()
    {
		if (!networkView.isMine) {
			SyncedMovement();
		}
    }*/

    void OnGUI()
    {
        if (!Network.isServer && !Network.isClient)
        {
            if (GUI.Button(new Rect(25f, 25f, 150f, 30f), "Start new Server"))
            {
                StartServer();
            }

            if (GUI.Button(new Rect(25f, 65f, 150f, 30f), "Refresh Server List"))
            {
                StartCoroutine("RefreshHostList");
            }

            if (hostData != null)
            {
                for (int i = 0; i < hostData.Length; i++)
                {
                    if (GUI.Button(new Rect(Screen.width / 2, 65f + (30f * i), 300f, 30f), hostData[i].gameName))
                    {
                        JoinServer(hostData[i]);
                    }
                }
            }
        }
    }
}
