using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MainSceneCtrlInter : MonoBehaviour {

    [Header("Jogar")]
    public Button Jogar;


    [Header("ModoJogo")]

    public GameObject InterSala;
    public Button ModoGame;
    public Button TempoGame;
    public Button CriarSala;

    [Header("Equipe")]
    public GameObject InterEquipe;
    public Button PlayerRed;
    public Button PlayerBlue;
    public Text JogadoresRed;
    public Text JogadoresBlue;

    [Header("Personagem")]
    public GameObject InterPersonagem;
    public Button Back;
    public Button Front;
    public Button Escolher;

    [Header("Aguardar")]
    public GameObject InterAguardar;
    public Text JogadoresSala;

    [Header("Imagens")]
    public Sprite Carrack;
    public Sprite Eloise;
    public Sprite Galeon;
    public Sprite Betta;


    NetworkManager nm;

    public static int idTeam;
    public static int id;

	void Start () 
    {
        nm = new NetworkManager();
	}
	
	void Update () 
    {
        //if (Equipe.activeSelf)
        //{
        //    JogadoresRed.text = PhotonNetwork.room.playerCount.ToString();
        //}

        //testando somente aparecer quando conectar
        if (InterAguardar.activeSelf )
        {
            JogadoresSala.text = "Jogadores na sala: "+ PhotonNetwork.room.playerCount.ToString();
            if (PhotonNetwork.room.playerCount >= 1)
            {
                InterAguardar.SetActive(false);
                nm.SetAuxPartida(true);
            }
          
            
        }

	}

    public void BtnJogar()
    {
        Jogar.gameObject.SetActive(false);
       // InterSala.SetActive(true);
        nm.Connect();
        InterEquipe.SetActive(true);

    }

    public void CriarPartida()
    {
        //InterSala.SetActive(false);
        InterEquipe.SetActive(true);

    }

    public void EscolherPersonagem()
    {
        InterPersonagem.SetActive(false);

     //  if(PhotonNetwork.connected == false)
        InterAguardar.SetActive(true);
    }

    public void EquipeRed()
    {
        idTeam = 1;
       // SetIdTeam(1);
        id = 1;
        InterEquipe.SetActive(false);
        InterPersonagem.SetActive(true);
        InterPersonagem.transform.GetChild(0).GetComponent<Image>().sprite = Carrack;
        Debug.Log("idteam " + idTeam);
    }

    public void EquipeBlue()
    {
        idTeam = 2;
       // SetIdTeam(2);
        id = 1;
        InterEquipe.SetActive(false);
        InterPersonagem.SetActive(true);
        InterPersonagem.transform.GetChild(0).GetComponent<Image>().sprite = Galeon;
    
    }

    public void BtnBack()
    {
        if (idTeam == 1 && id == 1)
        {
            id = 2;
            InterPersonagem.transform.GetChild(0).GetComponent<Image>().sprite = Eloise;

        }
        else if (idTeam == 2 && id == 1)
        {
            id = 2;
            InterPersonagem.transform.GetChild(0).GetComponent<Image>().sprite = Betta;

        }
        else if (idTeam == 1 && id == 2)
        {
            id = 1;
            InterPersonagem.transform.GetChild(0).GetComponent<Image>().sprite = Carrack;
        }
        else if (idTeam == 2 && id == 2)
        {
            id = 1;
            InterPersonagem.transform.GetChild(0).GetComponent<Image>().sprite = Galeon;

        }

    }

    public void BtnFront() 
    {
      
        if (idTeam == 1 && id == 1)
        {
            id = 2;
            InterPersonagem.transform.GetChild(0).GetComponent<Image>().sprite = Eloise;

        }
        else if (idTeam == 2 && id == 1)
        {
            id = 2;
            InterPersonagem.transform.GetChild(0).GetComponent<Image>().sprite = Betta;

        }
        else if (idTeam == 1 && id == 2)
        {
            id = 1;
            InterPersonagem.transform.GetChild(0).GetComponent<Image>().sprite = Carrack;

        }
        else if (idTeam == 2 && id == 2)
        {
            id = 1;
            InterPersonagem.transform.GetChild(0).GetComponent<Image>().sprite = Galeon;

        }

    }

    public int GetIdTeam()
    {
        return idTeam;
    }

    //public void SetIdTeam(int id_Team)
    //{
    //    idTeam = id_Team;
    //}
}
