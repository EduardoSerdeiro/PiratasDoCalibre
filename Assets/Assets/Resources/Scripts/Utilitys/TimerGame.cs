using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TimerGame : MonoBehaviour {

    public Text Timer;

    public static bool startTime = false;
    private float minutos = 0;
    private float segundos = 0;
    private float milisegundos = 0;


    void Awake()
    {
        Timer = GameObject.Find("Timer").GetComponent<Text>();
    }

	void Start () {
        if (PlayerPrefs.HasKey("tempoMinu")== true)
        {
            minutos = PlayerPrefs.GetFloat("tempoMinu") ; 
        }

        segundos = 01;
        milisegundos = 0;
	}
	
	void Update () {


        if (startTime)
        {
            if (milisegundos <= 0)
            {
                if (segundos <= 0)
                {
                    minutos--;
                    segundos = 59;
                }
                else if (segundos >= 0)
                {
                    segundos--;
                }

                milisegundos = 100;
            }

            milisegundos -= Time.deltaTime * 100;

            Timer.text = string.Format("{0} : {1}", minutos, segundos);


            if (minutos <= 0 && segundos <= 0 && milisegundos <= 0)
            {
                Debug.Log("Acabou o tempo");
                startTime = false;
            }
        }

	}

    public bool GetStartTime()
    {

        return startTime;
    }

    public void SetStartTime(bool start_Time)
    {
        startTime = start_Time;
    }
}
