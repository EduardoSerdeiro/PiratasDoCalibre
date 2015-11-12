using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

    public GameObject[] SpawnsPlayers;

	void Start () {

        //SpawnsPlayers = GameObject.FindObjectsOfType<SpawnPlayer>();
        SpawnsPlayers = GameObject.FindGameObjectsWithTag("Spawn");

        Connect();
        PhotonNetwork.offlineMode = true;
        OnJoinedLobby();
        SpawnPlayers();

      //  CriarSala();

       

	}
	
	void Update () {

       // Debug.Log(PhotonNetwork.connected);

	}

    public void Connect()
    {
      
        PhotonNetwork.ConnectUsingSettings("PdC v0.4");
       
    }

    void OnJoinedLobby()
    {
        Debug.Log("OnJoinedLobby");
        PhotonNetwork.JoinRandomRoom();
    }

    void OnPhotonRandomJoinFailed()
    {
        Debug.Log("OnPhotonRandomJoinFailed");
        PhotonNetwork.CreateRoom(null);
    }
  

    void EntrarSalaRandom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    void CriarSala()
    {
        PhotonNetwork.CreateRoom("Sala1");
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
