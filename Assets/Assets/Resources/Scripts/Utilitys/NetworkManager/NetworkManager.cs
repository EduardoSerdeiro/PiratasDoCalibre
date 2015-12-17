using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

    MainSceneCtrlInter mainSceneInter;

    private int playersMax;

   string playerName;

   TimerGame timeGame;

   private bool iniciarPartida;

   public GameObject[] SpawnsPlayers;

   [HideInInspector]
   public float respawnTime;

   [HideInInspector]
   public int contMorte = 0;

   private static bool auxPartida;

    [Header("Team")]
   string strCaminho;
   //public static float tempoPartida;

  // private TypedLobby lobbyName = new TypedLobby("New_Lobby", LobbyType.Default);
  // private RoomInfo[] roomsList;

   void Start()
   {
       timeGame = new TimerGame();
       SpawnsPlayers = GameObject.FindGameObjectsWithTag("Spawn");
       mainSceneInter = new MainSceneCtrlInter();

       playersMax = 8;

       PhotonNetwork.autoJoinLobby = true;


     //  Connect();

   }
	void Update () {
        RespawnPlayer();

        if (auxPartida == true)
        {
            if (PhotonNetwork.room.playerCount >= 1 )
            {
                iniciarPartida = true;
               // Debug.Log("entrou inicioParti");
            }

            if (iniciarPartida)
            {
                //Debug.Log("xablau");
                timeGame.SetStartTime(true);
                SpawnPlayer();
                iniciarPartida = false;
                auxPartida = false;
            }


        }
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
      
            Debug.Log("OnJoinedLobby");
            RoomOptions roomOp = new RoomOptions() { isVisible = true, maxPlayers = (byte)(playersMax) };
            PhotonNetwork.JoinOrCreateRoom("Sala1", roomOp, TypedLobby.Default);
      
        //PhotonNetwork.JoinRandomRoom();
    }
    public void OnPhotonRandomJoinFailed()
    {
            Debug.Log("OnPhotonRandomJoinFailed");
            // PhotonNetwork.CreateRoom("Sala1", new RoomOptions() { maxPlayers = (byte)(playersMax * 2) }, null);
            PhotonNetwork.JoinRandomRoom();
    }

    public void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom");
       // auxPartida = true;

    }

    public void SpawnPlayer()
    {
       // this.id = id;
        GameObject MySpawn = SpawnsPlayers[Random.Range(0, SpawnsPlayers.Length)];

        if (mainSceneInter.GetIdTeam() == 1 && mainSceneInter.GetId() == 1)
        {
            strCaminho = "Prefabs/Characters/PlayerCarrack";
        }
        else if (mainSceneInter.GetIdTeam() == 2)
        {
            strCaminho = "Prefabs/Characters/PlayerGalleon";
        }


        GameObject MyPlayer = (GameObject)PhotonNetwork.Instantiate(strCaminho, MySpawn.transform.position, MySpawn.transform.rotation, 0);
        ((MonoBehaviour)MyPlayer.GetComponent("FirstPersonController")).enabled = true;
        MyPlayer.GetComponent<CharacterController>().enabled = true;
        ((MonoBehaviour)MyPlayer.GetComponent("Agachar")).enabled = true;

        GameObject mainCamera = GameObject.Find("Main Camera");
        mainCamera.GetComponent<AudioListener>().enabled = false;

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
            SpawnPlayer();
            respawnTime = 0;

            if (contMorte < 56)
                contMorte++;
        }
    }

    public void SetAuxPartida(bool valor)
    {
        auxPartida = valor;

    }


    void OnGUI()
    {
        if (PhotonNetwork.connected)
        {
            GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
        }

        //else if (PhotonNetwork.room == null)
        //{

        //     //Create Room
        //    if (GUI.Button(new Rect(Screen.width / 2 - 125, Screen.height / 2 - 20, 250, 40), "Criar Sala"))
        //    {
        //        PhotonNetwork.CreateRoom("Sala 1", new RoomOptions() { maxPlayers = 8, isOpen = true, isVisible = true }, lobbyName);
        //    }

        //    // Join Room
        //    if (roomsList != null)
        //    {
        //        Debug.Log("dentro room != null");
        //        for (int i = 0; i < roomsList.Length; i++)
        //        {
        //            if (GUI.Button(new Rect(Screen.width / 2 - 125, Screen.height / 2 + 20, 250, 40), "Logar em: " + roomsList[i].name + " " + "(" + roomsList[i].playerCount + "/" + roomsList[i].maxPlayers + ")"))
        //            {
        //                PhotonNetwork.JoinRoom(roomsList[i].name);
        //                if(roomsList[i].playerCount >= 1)
        //                {
        //                    SpawnPlayers();
        //                    timeGame.SetStartTime(true);
        //                }
        //            }
        //        }
        //    }
        //}
       
    }

   
}
