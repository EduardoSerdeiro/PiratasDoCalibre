using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

    TimerGame timeGame;

    private int playersMax;

    public GameObject[] SpawnsPlayers;

   [HideInInspector] public float respawnTime;

   [HideInInspector] public int contMorte = 0;

   private TypedLobby lobbyName = new TypedLobby("New_Lobby", LobbyType.Default);
   private RoomInfo[] roomsList;

	void Start () {

        timeGame = new TimerGame();
        //SpawnsPlayers = GameObject.FindObjectsOfType<SpawnPlayer>();
        SpawnsPlayers = GameObject.FindGameObjectsWithTag("Spawn");

        if (PlayerPrefs.HasKey("playerTeam") == true)
        {
            playersMax = PlayerPrefs.GetInt("playerTeam");
        }

       // Debug.Log("playMax : " +playersMax);
        PhotonNetwork.autoJoinLobby = true;
        //PhotonNetwork.logLevel = PhotonLogLevel.Full;
        Connect();
        
        	}
	
	void Update () {
        RespawnPlayer();
	}

    public void Connect()
    {
        PhotonNetwork.ConnectUsingSettings("PdC v0.4");
    }

    //public void OnConnectedToMaster()
    //{
    //    Debug.Log("OnConnectedToMaster");
    //    PhotonNetwork.CreateRoom("Sala1");
    //    //PhotonNetwork.JoinRandomRoom();
    //}

    public void OnJoinedLobby()
    {
        //PhotonNetwork.JoinOrCreateRoom("Sala1", new RoomOptions() { maxPlayers = (byte)(playersMax * 2) }, null);
        //PhotonNetwork.JoinRandomRoom();
    }
    void OnPhotonRandomJoinFailed()
    {
        Debug.Log("OnPhotonRandomJoinFailed");
       // PhotonNetwork.CreateRoom("Sala1", new RoomOptions() { maxPlayers = (byte)(playersMax*2)}, null);
        PhotonNetwork.JoinRandomRoom();
    }

    void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom");
    }

    void OnGUI()
    {
        if (!PhotonNetwork.connected)
        {
            GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
        }

        else if (PhotonNetwork.room == null)
        {
            // Create Room
            if (GUI.Button(new Rect(Screen.width / 2 - 125, Screen.height / 2 - 20, 250, 40), "Criar Sala"))
            {
                PhotonNetwork.CreateRoom("Sala 1", new RoomOptions() { maxPlayers = 8, isOpen = true, isVisible = true }, lobbyName);
            }

            // Join Room
            if (roomsList != null)
            {
                for (int i = 0; i < roomsList.Length; i++)
                {
                    if (GUI.Button(new Rect(Screen.width / 2 - 125, Screen.height / 2 + 20, 250, 40), "Logar em: " + roomsList[i].name + " " + "(" + roomsList[i].playerCount + "/" + roomsList[i].maxPlayers + ")"))
                    {
                        PhotonNetwork.JoinRoom(roomsList[i].name);
                        if(roomsList[i].playerCount >= 2)
                        {
                            SpawnPlayers();
                            timeGame.SetStartTime(true);
                        }
                    }
                }
            }
        }
       
    }

    private void SpawnPlayers()
    {

        GameObject MySpawn = SpawnsPlayers[Random.Range(0, SpawnsPlayers.Length)];

        GameObject MyPlayer = (GameObject)PhotonNetwork.Instantiate("Prefabs/Characters/PlayerPirataRed", MySpawn.transform.position, MySpawn.transform.rotation, 0);
        ((MonoBehaviour)MyPlayer.GetComponent("FirstPersonController")).enabled = true;
        MyPlayer.GetComponent<CharacterController>().enabled = true;
       ((MonoBehaviour)MyPlayer.GetComponent("Agachar")).enabled = true;
        MyPlayer.transform.GetChild(0).GetComponent<Camera>().enabled = true;
    }

    public void RespawnPlayer()
    {
        if (respawnTime > 0)
        {
            respawnTime -= Time.deltaTime;
        }
        else if (respawnTime < 0)
        {
            SpawnPlayers();
            respawnTime = 0;

            if(contMorte < 56)
            contMorte++;
        }
    }

   
}
