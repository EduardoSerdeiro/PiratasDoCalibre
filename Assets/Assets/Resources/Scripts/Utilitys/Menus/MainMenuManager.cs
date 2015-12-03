﻿using UnityEngine;
using System.Collections;

public class MainMenuManager : MonoBehaviour {

   


    public void Jogar()
    {
        Application.LoadLevel("MenuPartida");
    }

    public void Config()
    {
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