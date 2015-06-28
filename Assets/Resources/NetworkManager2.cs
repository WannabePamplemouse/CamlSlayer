using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net;

public class NetworkManager2 : MonoBehaviour {

	string registeredGameName = "WannabeePamplemousse_CamlSlayer_Multiplayer";
	bool isRefreshing = false;
	float refreshRequestLength = 3.0f;
	HostData[] hostData;
	List<string> gamerNames;
	List<string> games;
	int nbplayer = 0;
	int nbgames = 1;

	public static string HostIP;
	public static string SecondPlayerIP;
	public static bool isMulti;
	public static bool isPlayer;
	public static bool isRobotGun;

	public static GameObject Robot;
	public static GameObject RobotGun;

	int selGridInt = 0;
	string [] selStrings;
	public int worldchosen;

	void Awake()
	{
		gamerNames = new List<string> ();
		games = new List<string> ();
	}

	private void StartServer()
	{
		Network.InitializeServer (5, 25000, false);
		MasterServer.RegisterHost (registeredGameName, "CamlSlayer Multiplayer", "Here you can test the multiplayer !");
		NetworkPlayer host = new NetworkPlayer ();
		HostIP = host.ipAddress;
	}

	void OnServerInitialized()
	{
		Debug.Log ("Server has been created successfully !");
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
		/*if(nbplayer == 0)
			games.Add ("Game " + nbgames);

		nbplayer++;

		gamerNames.Add ("Player " + nbplayer);

		Debug.Log (nbplayer);*/


		//not working yet but good idea (same computer #sueg)
		NetworkPlayer caca = new NetworkPlayer ();
		SecondPlayerIP = caca.ipAddress + "1";

	}

	void OnDisconnectedFromServer(NetworkDisconnection info)
	{
	}

	void OnFailedToConnect(NetworkConnectionError error)
	{
	}

	void OnPlayerConnected (NetworkPlayer player)
	{
	}

	void OnPlayerDisconnected (NetworkPlayer player)
	{
	}

	void OnFailedToConnectedToMasterServer(NetworkConnectionError info)
	{
	}

	void OnNetworkInstantiate(NetworkMessageInfo info)
	{
	}


	void Update()
	{
		if(Network.isServer)
			isPlayer = true;
		else if(Network.isClient)
			isRobotGun = true;
	}



	private void LoadLevel()
	{
		if (GUI.Button (new Rect (30f, 60f, 70f, 30f), "World 1"))
			Application.LoadLevel ("Monde1");
		else if (GUI.Button (new Rect (30f, 100f, 70f, 30f), "World 2"))
			Application.LoadLevel ("Monde2");
		else if (GUI.Button (new Rect (30f, 140f, 70f, 30f), "World 3"))
			Application.LoadLevel ("Monde3");
		else if (GUI.Button (new Rect (30f, 180f, 70f, 30f), "World 4"))
			Application.LoadLevel ("Monde4");

	}
	private void GameManager()
	{
		Debug.Log (nbplayer);

		if (nbplayer != 2) 
			isPlayer = true;
		else 
		{
			nbplayer = 0;
			isRobotGun = true;

		}
	}


	void OnGUI()
	{
		if (Network.isServer)
			GUILayout.Label ("You are running as a server");
		else if (Network.isClient)
			GUILayout.Label ("You are running as a client");


		if (Network.isServer) 
		{
			selStrings = new string[4];
			for (int i = 0; i < selStrings.Length; i++) 
			{
				selStrings[i] = "World " + (i + 1);
			}

			selGridInt = GUI.SelectionGrid (new Rect (120, 60, 120, 365), selGridInt, selStrings, 1);
			worldchosen = selGridInt;
			if(GUI.Button(new Rect(300f, 60f, 50f, 50f), "Load"))
			{
				switch (selGridInt) 
				{
				case 0:
					Application.LoadLevel("Monde1");
					break;
				case 1:
					Application.LoadLevel("Monde2");
					break;
				case 2:
					Application.LoadLevel("Monde3");
					break;
				case 3:
					Application.LoadLevel("Monde4");
					break;
				}
			}
		}

		if (Network.isClient) 
		{
			Application.LoadLevel("Monde" + (worldchosen + 1));
		}

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
