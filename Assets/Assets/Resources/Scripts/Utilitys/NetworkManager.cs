using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

    TimerGame timeGame;

    private int playersMax;

    public GameObject[] SpawnsPlayers;



	void Start () {
        timeGame = new TimerGame();
        //SpawnsPlayers = GameObject.FindObjectsOfType<SpawnPlayer>();
        SpawnsPlayers = GameObject.FindGameObjectsWithTag("Spawn");

        if (PlayerPrefs.HasKey("playerTeam") == true)
        {
            playersMax = PlayerPrefs.GetInt("playerTeam");
        }

        Debug.Log("playMax : " +playersMax);
        PhotonNetwork.autoJoinLobby = true;
        //PhotonNetwork.logLevel = PhotonLogLevel.Full;
        Connect();
        
        	}
	
	void Update () {

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
        PhotonNetwork.JoinRandomRoom();
    }
    void OnPhotonRandomJoinFailed()
    {
        Debug.Log("OnPhotonRandomJoinFailed");
        PhotonNetwork.CreateRoom("Sala1", new RoomOptions() { maxPlayers = (byte)(playersMax*2)}, null);
        //PhotonNetwork.JoinRandomRoom();
    }

    void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom");
        //Debug.Log(PhotonNetwork.room.name);
        SpawnPlayers();
        timeGame.SetStartTime(true);
    }

    void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());

    }

    private void SpawnPlayers()
    {

        GameObject MySpawn = SpawnsPlayers[Random.Range(0, SpawnsPlayers.Length)];

        GameObject MyPlayer = (GameObject)PhotonNetwork.Instantiate("Prefabs/Characters/Player", MySpawn.transform.position, MySpawn.transform.rotation, 0);
        ((MonoBehaviour)MyPlayer.GetComponent("FirstPersonController")).enabled = true;
        MyPlayer.GetComponent<CharacterController>().enabled = true;
       ((MonoBehaviour)MyPlayer.GetComponent("Agachar")).enabled = true;
        MyPlayer.transform.GetChild(0).GetComponent<Camera>().enabled = true;
    }

   
}
