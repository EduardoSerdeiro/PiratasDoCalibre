using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PegarOuro : MonoBehaviour {

    public GameObject barraProgresso;
    private Slider barraProgresSlider;
    public static bool pertoBau = false;
    public static bool pegouOuro = false;
    public float speedBarra = 20;


    public GameObject canvas;
	void Start () {

        canvas = GameObject.Find("Canvas");
        barraProgresso = GameObject.Find("Canvas").transform.GetChild(8).gameObject;
        barraProgresso = canvas.GetComponent<MainSceneCtrlInter>().barraProgres ;
       // barraProgresso.SetActive(false);
        barraProgresSlider = barraProgresso.GetComponent<Slider>();
        
        
	}
	
	void Update () {

        if (pertoBau)
        {
           // Debug.Log("Proximo do bau");
            if(Input.GetKey(KeyCode.E) && pegouOuro == false)
            {
                barraProgresso.SetActive(true);
                barraProgresSlider.value += Time.deltaTime * speedBarra;
                if (barraProgresSlider.value == 100)
                {
                    pegouOuro = true;
                    barraProgresso.SetActive(false);
                }
            }
            if (barraProgresso.activeSelf == true && Input.GetKeyUp(KeyCode.E))
            {
                barraProgresso.SetActive(false);
                barraProgresSlider.value = 0;
            }
        }
        else
        {
           // Debug.Log("Longe do bau");

            barraProgresso.SetActive(false);
            barraProgresSlider.value = 0;
        }

	}

    public void SetPertoBau(bool pertoBau2)
    {
        pertoBau = pertoBau2;
    }

    public bool GetPegouOuro()
    {
        return pegouOuro;
    }
    public void SetPegouOuro(bool aux)
    {
        pegouOuro = aux;
    }
}
