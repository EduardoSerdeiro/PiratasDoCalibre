using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuPartiManager : MonoBehaviour
{

    private Button BtnMode, BtnTime, BtnVoltar, BtnCriarSala;

    private Text TxtMode, TxtTime;

    private float tempoMinu;
    private short contTime ;
    private short contMode;

    //team true = 4x4 / team false = 8x8;
    public short playerTeam;

	void Start () {

        BtnMode = this.transform.GetChild(1).GetComponent<Button>();
        TxtMode = this.transform.GetChild(1).GetComponent<Button>().GetComponentInChildren<Text>();
        BtnTime = this.transform.GetChild(3).GetComponent<Button>();
        TxtTime = this.transform.GetChild(3).GetComponent<Button>().GetComponentInChildren<Text>();
        BtnCriarSala = this.transform.GetChild(4).GetComponent<Button>();
        BtnVoltar = this.transform.GetChild(5).GetComponent<Button>();

        tempoMinu = 5;
        contTime = 1;
        TxtTime.text = tempoMinu.ToString() + " Minutos";
        PlayerPrefs.SetFloat("tempoMinu", tempoMinu);

        contMode = 1;
        TxtMode.text = "4x4 Jogadores";
        playerTeam = 4;
	}

    void Update()
    {
       
    }


    public void MenuVoltar()
    {
        Application.LoadLevel("MenuLogin");
    }


    public void ChangeTime()
    {
        if (contTime == 0)
        {
            tempoMinu = 5;
            TxtTime.text = tempoMinu.ToString() + " Minutos";
            contTime++;
        }
        else if (contTime == 1)
        {
            tempoMinu = 7;
            TxtTime.text = tempoMinu.ToString() + " Minutos";
            contTime++;
        }
        else if(contTime == 2)
        {
            tempoMinu = 10;
            TxtTime.text = tempoMinu.ToString() +" Minutos";
            contTime++;
            if (contTime > 2)
            {
                contTime = 0;
            }
        }

        PlayerPrefs.SetFloat("tempoMinu", tempoMinu);


    }

    public void ChangeMode()
    {
        if(contMode == 0)
        {
            TxtMode.text = "4x4 Jogadores";
            playerTeam = 4;
           contMode++;
       
        }
        else if (contMode == 1)
        {
            TxtMode.text = "8x8 Jogadores";
            playerTeam = 8;
            contMode--;
        }
    }


    public void CriarSala()
    {
        Application.LoadLevel("MainScene");
       //PhotonNetwork.LoadLevel("MainScene");


    }

}
