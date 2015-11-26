using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuConfigManager : MonoBehaviour {

   [SerializeField]private Button btnMutar;
   [SerializeField]
   private Slider sliderVolume;

   [SerializeField]
   private Button btnResolu;

public Text txtResolu;


   private int contadorResolu = 0;

	void Start () {
        btnMutar = this.transform.GetChild(1).GetComponent<Button>();
        sliderVolume = this.transform.GetChild(0).GetComponent<Slider>();
        btnResolu = this.transform.GetChild(5).GetComponent<Button>();
        txtResolu = this.transform.GetChild(5).GetComponentInChildren<Text>();
        txtResolu.text = "Resolução: " + Screen.width + "x" + Screen.height;

	}
	
	void Update () {

        AudioListener.volume = sliderVolume.value;


	}

    public void Mutar()
    {
        //     AudioListener.volume = 0;
        if (AudioListener.pause)
        {
             AudioListener.pause = false;
          
        }
        else
        {
            AudioListener.pause = true;
      
        }

        
    }

    public void ChangeResolution()
    {
        if (contadorResolu == 0)
        {
            Screen.SetResolution(1366, 766, true);
            txtResolu.text = "Resolução: " + "1366x766";
            contadorResolu++;
        }
        else if (contadorResolu == 1)
        {
            Screen.SetResolution(1024, 768, true);
            txtResolu.text = "Resolução: " + "1024x766";
            contadorResolu++;
        }
        else if (contadorResolu == 2)
        {
            Screen.SetResolution(800, 600, true);
            txtResolu.text = "Resolução: " + "800x600";
            contadorResolu++;
        }

        if (contadorResolu >= 3)
        {
            contadorResolu = 0;
        }

    }

    public void Voltar()
    {
        Application.LoadLevel("MainMenu");
    }

}
