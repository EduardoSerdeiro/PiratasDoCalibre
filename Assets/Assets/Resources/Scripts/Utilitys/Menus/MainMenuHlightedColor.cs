using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MainMenuHlightedColor : MonoBehaviour
{
    public Button btnJogar;
    public Text textJogar;

    public Text textConfig;
    public Text textCredits;
    public Text textSair;

    public void TxtJgarColorEnter()
    {
        textJogar.color = Color.Lerp(Color.red, Color.yellow, 0.3f);
    }
    public void TxtJgarColorExit()
    {
        textJogar.color = Color.white;
    }


    public void TxtConfigColorEnter()
    {
        textConfig.color = Color.Lerp(Color.red, Color.yellow, 0.3f);
    }
    public void TxtConfigColorExit()
    {
        textConfig.color = Color.white;
    }

    public void TxtCreditColorEnter()
    {
        textCredits.color = Color.Lerp(Color.red, Color.yellow, 0.3f);
    }
    public void TxtCreditColorExit()
    {
        textCredits.color = Color.white;
    }

    public void TxtQuitColorEnter()
    {
        textSair.color = Color.Lerp(Color.red, Color.yellow, 0.3f);
    }
    public void TxtQuitColorExit()
    {
        textSair.color = Color.white;
    }

}
