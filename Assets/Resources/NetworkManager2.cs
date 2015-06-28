using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NetworkManager2 : MonoBehaviour {

	string registeredGameName = "WannabeePamplemousse_CamlSlayer_Multiplayer";
	bool isRefreshing = false;
	float refreshRequestLength = 3.0f;
	HostData[] hostData;
	List<string> gamerNames;
	int nbplayer = 0;


	public static bool isMulti;
	public static bool isPlayer;
	public static bool isRobotGun;

	void Awake()
	{
		gamerNames = new List<string> ();
	}

	private void StartServer()
	{
		Network.InitializeServer (5, 25000, false);
		MasterServer.RegisterHost (registeredGameName, "CamlSlayer Multiplayer", "Here you can test the multiplayer !");
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
		nbplayer++;
		gamerNames.Add ("Joueur" + nbplayer.ToString());
		if (nbplayer == 2) 
		{
			GUILayout.Label ("This game is full, please start again to find another one");
			if (GUI.Button (new Rect (30f, 30f, 150f, 30f), "Player")) 
			{
				isPlayer = true;
			}
			
			if (GUI.Button (new Rect (30f, 190f, 150f, 30f), "RobotGun")) 
			{
				isRobotGun = true;
			}
		} 
		else
			return;
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






	void OnGUI()
	{
		if (Network.isServer)
			GUILayout.Label ("You are running as a server");
		else if (Network.isClient)
			GUILayout.Label ("You are running as a client");


		if (Network.isClient) 
		{


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
