using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuLoginManager : MonoBehaviour {

    Connection conn = new Connection();

    [SerializeField]Text textLogin, textSenha, texStatus;
    [SerializeField]InputField inputLogin, inputSenha;
    [SerializeField]Button botaoLogar, botaoCadast, botaoSair, botaoAutent, botaoVoltar;


	// Use this for initialization
	void Start () {

        Inicio();
	}
	
	// Update is called once per frame
	void Update ()
    {

        #region TAB pra mudar o campo

        if (Input.GetKeyDown(KeyCode.Tab) && inputLogin.isFocused)
            inputSenha.Select();

        else if (Input.GetKeyDown(KeyCode.Tab) && inputSenha.isFocused)
            inputLogin.Select();

        #endregion


    }

    public void Inicio()
    {
        botaoLogar.gameObject.SetActive(true);
        botaoCadast.gameObject.SetActive(true);
        botaoSair.gameObject.SetActive(true);
        textLogin.gameObject.SetActive(false);
        inputLogin.gameObject.SetActive(false);
        textSenha.gameObject.SetActive(false);
        inputSenha.gameObject.SetActive(false);
        botaoAutent.gameObject.SetActive(false);
        botaoVoltar.gameObject.SetActive(false);
    }

    public void clickLogar()
    {
        botaoLogar.gameObject.SetActive(false);
        botaoCadast.gameObject.SetActive(false);
        botaoSair.gameObject.SetActive(false);
        textLogin.gameObject.SetActive(true);
        inputLogin.gameObject.SetActive(true);
        textSenha.gameObject.SetActive(true);
        inputSenha.gameObject.SetActive(true);
        botaoAutent.gameObject.SetActive(true);
        botaoVoltar.gameObject.SetActive(true);

        

    }

    public void clickCadastrar()
    {
        botaoLogar.gameObject.SetActive(false);
        botaoCadast.gameObject.SetActive(false);
        botaoSair.gameObject.SetActive(false);
        textLogin.gameObject.SetActive(false);
        inputLogin.gameObject.SetActive(false);
        textSenha.gameObject.SetActive(false);
        inputSenha.gameObject.SetActive(false);
        botaoAutent.gameObject.SetActive(false);
        botaoVoltar.gameObject.SetActive(false);

        Application.OpenURL("http://google.com");
    }

    public void clickSair()
    {
        Application.Quit();
    }

    public void clickAutent()
    {

        if (conn.Logar(inputLogin.text, inputSenha.text))
        {
           // PlayerPrefs.SetString("PlayerName", inputLogin.text);
            PhotonNetwork.playerName = inputLogin.text;
            texStatus.text = "Acesso Permitido";
         
            Application.LoadLevel("MainMenu");
        }
        else
        {
            texStatus.text = "Acesso Negado";
        }
       
    }

    public void clickVoltar()
    {
        texStatus.text = "";
        Inicio();

    }

}
