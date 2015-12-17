using UnityEngine;
using System.Collections;

public class MainMenuManager : MonoBehaviour {


    public void Jogar()
    {
        Application.LoadLevel("MainScene");
    }

    public void Config()
    {
        GameObject background = GameObject.Find("ImgFundo");
     
        Application.LoadLevel("Config");
    }

    public void Creditos()
    {
        Application.LoadLevel("Creditos");
    }

    public void Sair()
    {
       Application.Quit();
    }

}
