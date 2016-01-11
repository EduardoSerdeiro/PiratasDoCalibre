using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MainSceneCtrlInter : MonoBehaviour {

    [Header("ModoJogo")]
    public GameObject InterSala;
    public Button ModoGame;
    public Button TempoGame;
    public Button CriarSala;

    [Header("Equipe")]
    public GameObject InterEquipe;
    //public Button PlayerRed;
    //public Button PlayerBlue;
    //public Text JogadoresRed;
    //public Text JogadoresBlue;

    [Header("Personagem")]
    public GameObject InterPersonagem;
    public Button Back;
    public Button Front;
    public Button Escolher;

    [Header("Aguardar")]
    public GameObject InterAguardar;
    public Text JogadoresSala;

    [Header("Imagens")]
    public Sprite EscudoVermelho;
    public Sprite EscudoAzul;
    public Sprite Carrack;
    public Sprite Eloise;
    public Sprite Galeon;
    public Sprite Betta;

    [Header("ButtonsPersonagens")]
    public GameObject btnP1;
    public GameObject btnP2;
    public GameObject btnP3;
    public GameObject btnP4;

    [Header("Barra de Progresso - Ouro")]
    public GameObject barraProgres;

    NetworkManager nm;

    public static int idTeam;
    public static int id;

	void Start () 
    {
        nm = new NetworkManager();
        nm.Connect();
        InterEquipe.SetActive(true);

        

	}
	
	void Update () 
    {
        if (InterAguardar.activeSelf)
        {
            JogadoresSala.text = "Jogadores na sala: "+ PhotonNetwork.room.playerCount.ToString();
            if (PhotonNetwork.room.playerCount >= 1)
            {
                InterAguardar.SetActive(false);
                nm.SetAuxPartida(true);
            }
          
            
        }

	}

    //public void CriarPartida()
    //{
    //    //InterSala.SetActive(false);
    //    InterEquipe.SetActive(true);

    //}

    public void EscolherPersonagem()
    {
        InterEquipe.SetActive(false);
        InterPersonagem.SetActive(false);
        InterAguardar.SetActive(true);
        Cursor.visible = false;
    }

    public void EquipeRed()
    {
        idTeam = 1;
       // SetIdTeam(1);
       // id = 1;
       // InterEquipe.SetActive(false);
        InterPersonagem.SetActive(true);
      //  InterPersonagem.transform.GetChild(5).GetComponent<Image>().sprite = Carrack;
        btnP1.SetActive(true);
        btnP2.SetActive(true);
        btnP3.SetActive(false);
        btnP4.SetActive(false);
      
       // Debug.Log("idteam " + idTeam);
    }

    public void EquipeBlue()
    {
        idTeam = 2;
       // SetIdTeam(2);

       // id = 1;
      //  InterEquipe.SetActive(false);
        InterPersonagem.SetActive(true);

        btnP1.SetActive(false);
        btnP2.SetActive(false);
        btnP3.SetActive(true);
        btnP4.SetActive(true);
     
    }

    public void CarrackOuGalleon()
    {
        id = 1;
        EscolherPersonagem();

    }

    public void EloiseOuBetta()
    {
        id = 2;
        EscolherPersonagem();
    }
    //public void BtnBack()
    //{
    //    if (idTeam == 1 && id == 1)
    //    {
    //        id = 2;
    //        InterPersonagem.transform.GetChild(0).GetComponent<Image>().sprite = Eloise;
    //        InterPersonagem.transform.GetChild(4).GetComponentInChildren<Text>().text = "Eloise";
    //    }
    //    else if (idTeam == 2 && id == 1)
    //    {
    //        id = 2;
    //        InterPersonagem.transform.GetChild(0).GetComponent<Image>().sprite = Betta;
    //        InterPersonagem.transform.GetChild(4).GetComponentInChildren<Text>().text = "Betta";

    //    }
    //    else if (idTeam == 1 && id == 2)
    //    {
    //        id = 1;
    //        InterPersonagem.transform.GetChild(0).GetComponent<Image>().sprite = Carrack;
    //        InterPersonagem.transform.GetChild(4).GetComponentInChildren<Text>().text = "Carrack";
    //    }
    //    else if (idTeam == 2 && id == 2)
    //    {
    //        id = 1;
    //        InterPersonagem.transform.GetChild(0).GetComponent<Image>().sprite = Galeon;
    //        InterPersonagem.transform.GetChild(4).GetComponentInChildren<Text>().text = "Galleon";

    //    }

    //}

    //public void BtnFront() 
    //{
      
    //    if (idTeam == 1 && id == 1)
    //    {
    //        id = 2;
    //        InterPersonagem.transform.GetChild(0).GetComponent<Image>().sprite = Eloise;
    //        InterPersonagem.transform.GetChild(4).GetComponentInChildren<Text>().text = "Eloise";

    //    }
    //    else if (idTeam == 2 && id == 1)
    //    {
    //        id = 2;
    //        InterPersonagem.transform.GetChild(0).GetComponent<Image>().sprite = Betta;
    //        InterPersonagem.transform.GetChild(4).GetComponentInChildren<Text>().text = "Betta";

    //    }
    //    else if (idTeam == 1 && id == 2)
    //    {
    //        id = 1;
    //        InterPersonagem.transform.GetChild(0).GetComponent<Image>().sprite = Carrack;
    //        InterPersonagem.transform.GetChild(4).GetComponentInChildren<Text>().text = "Carrack";

    //    }
    //    else if (idTeam == 2 && id == 2)
    //    {
    //        id = 1;
    //        InterPersonagem.transform.GetChild(0).GetComponent<Image>().sprite = Galeon;
    //        InterPersonagem.transform.GetChild(4).GetComponentInChildren<Text>().text = "Galleon";

    //    }

    //}

    public int GetIdTeam()
    {
        return idTeam;
    }

    public int GetId()
    {
        return id;
    }

    //public void SetIdTeam(int id_Team)
    //{
    //    idTeam = id_Team;
    //}
}
