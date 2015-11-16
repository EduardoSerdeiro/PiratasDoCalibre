using UnityEngine;
using System.Collections;

public class Vazio : MonoBehaviour
{

    void Start()
    {
      //  PhotonNetwork.ConnectUsingSettings("0.1");
      //  RoomOptions options = new RoomOptions();
      //  options.maxPlayers = 4;
        //peer.OpCreateRoom("Room 42", options, TypedLobby.Default);
       // OnConnectedToMaster();
    }

    void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }


    //public void OnConnectedToMaster()
    //{
    //    Debug.Log("asda");
    //    PhotonNetwork.JoinRandomRoom();
    //}
    //void OnPhotonRandomJoinFailed()
    //{
    //    Debug.Log("OnPhotonRandomJoinFailed");
    //    PhotonNetwork.CreateRoom(null);
    //}
}
	
