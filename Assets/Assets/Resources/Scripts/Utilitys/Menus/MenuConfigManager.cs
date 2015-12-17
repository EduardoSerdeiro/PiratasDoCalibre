using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuConfigManager : MonoBehaviour {

   [SerializeField]private Button btnMutar;
   [SerializeField]private Slider sliderVolume;

   public Sprite iconeSom;
   public Sprite iconeSomX;

   [SerializeField]
   private Button btnResolu;

   private int contadorResolu = 0;

	void Start () {
        btnMutar = this.transform.GetChild(1).GetComponent<Button>();
        sliderVolume = this.transform.GetChild(0).GetComponent<Slider>();
        btnResolu.GetComponentInChildren<Text>().text =  Screen.width + "x" + Screen.height;

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
             btnMutar.GetComponent<Image>().sprite = iconeSom;//(Sprite)Resources.Load("Textures/Interfaces/Icones/iconeSomX");
          
        }
        else
        {
            AudioListener.pause = true;
            btnMutar.GetComponent<Image>().sprite = iconeSomX;
      
        }

        
    }

    public void ChangeResolution()
    {
        if (contadorResolu == 0)
        {
            Screen.SetResolution(1366, 766, true);
            btnResolu.GetComponentInChildren<Text>().text = "1366x766";
            contadorResolu++;
        }
        else if (contadorResolu == 1)
        {
            Screen.SetResolution(1024, 768, true);
            btnResolu.GetComponentInChildren<Text>().text = "1024x766";
            contadorResolu++;
        }
        else if (contadorResolu == 2)
        {
            Screen.SetResolution(800, 600, true);
            btnResolu.GetComponentInChildren<Text>().text = "800x600";
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
