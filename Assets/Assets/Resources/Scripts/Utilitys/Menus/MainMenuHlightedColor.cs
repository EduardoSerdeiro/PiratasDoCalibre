using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MainMenuHlightedColor : MonoBehaviour
{
    public Button btnJogar;
    public Text textJogar;

    private Color normal = new Color(0.15f,0.11f,0.07f);
    private Color highLight = new Color(0.69f, 0.56f, 0.47f);

    public Text textConfig;
    public Text textCredits;
    public Text textSair;

    public void TxtJgarColorEnter()
    {
        textJogar.color = highLight;
    }
    public void TxtJgarColorExit()
    {
        //textJogar.color = Color.white;
        textJogar.color = normal;
    }


    public void TxtConfigColorEnter()
    {
        textConfig.color = highLight;
    }
    public void TxtConfigColorExit()
    {
        textConfig.color = normal;
    }

    public void TxtCreditColorEnter()
    {
        textCredits.color = highLight;
    }
    public void TxtCreditColorExit()
    {
        textCredits.color = normal;
    }

    public void TxtQuitColorEnter()
    {
        textSair.color = highLight;
    }
    public void TxtQuitColorExit()
    {
        textSair.color = normal;
    }

}
