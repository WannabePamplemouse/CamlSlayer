using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net;

public class NetworkManager2 : MonoBehaviour {

	string registeredGameName = "WannabeePamplemousse_CamlSlayer_Multiplayer";
	bool isRefreshing = false;
	float refreshRequestLength = 3.0f;
	HostData[] hostData;

	public GameObject playerPref;
	public GameObject robotPref;

	public static GameObject Player;
	public static GameObject Robot;
	public static bool isMulti;

	private float lastSynchronizationTime = 0f;
	private float syncDelay = 0f;
	private float syncTime = 0f;
	private Vector3 syncStartPosition = Vector3.zero;
	private Vector3 syncEndPosition = Vector3.zero;

	void Awake()
	{

	}

	private void StartServer()
	{
		Network.InitializeServer (5, 25000, false);
		MasterServer.RegisterHost (registeredGameName, "CamlSlayer Multiplayer", "Here you can test the multiplayer !");
	}

	void OnServerInitialized()
	{
		Player = (GameObject)Network.Instantiate(playerPref, new Vector3(0f, 5f, 0f), Quaternion.identity, 0);
		GunControllerScript.player = Player;
	}

	void OnMasterServerEvent(MasterServerEvent masterServerEvent)
	{
		if (masterServerEvent == MasterServerEvent.RegistrationSucceeded)
			Debug.Log ("Registration successfull !");
	}

	public IEnumerator RefreshHostList()
	{
		MasterServer.RequestHostList (registeredGameName);
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
		Robot = (GameObject)Network.Instantiate(robotPref, new Vector3(0f, 10f, 0f), Quaternion.identity, 0);
	}

	void OnPlayerDisconnected(NetworkPlayer player)
	{
		Network.DestroyPlayerObjects (player);
	}

	void OnApplicationQuit()
	{
		if (Network.isServer) 
		{
			Network.Disconnect (200);
			MasterServer.UnregisterHost ();
		} 

		if(Network.isClient)
			Network.Disconnect (200);

	}

	void Update()
	{
	}
	
	void OnGUI()
	{
		if (!Network.isServer && !Network.isClient) 
		{
			if (GUI.Button (new Rect (25f, 25f, 150f, 30f), "Start new Server")) 
			{
				StartServer ();
			}

			if (GUI.Button (new Rect (25f, 65f, 150f, 30f), "Refresh Server List")) 
			{
				StartCoroutine ("RefreshHostList");
			}

			if (hostData != null) 
			{
				for (int i = 0; i < hostData.Length; i++) 
				{
					if (GUI.Button (new Rect (Screen.width / 2, 65f + (30f * i), 300f, 30f), hostData [i].gameName)) 
					{
						JoinServer(hostData[i]);
					}
				}
			}
		}
	}
}
