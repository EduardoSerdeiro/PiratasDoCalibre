using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FpsGame : MonoBehaviour {

    [SerializeField]
    private GameObject Fps;

    private Text TextFps;

    private int fpsAccumulator = 0;
    private float fpsNextPeriod = 0;
    private int currentFps;
    const float fpsPeriod = 0.5f;


	void Start () {
        
        Fps.SetActive(false);
        fpsNextPeriod = Time.realtimeSinceStartup + fpsPeriod;
        TextFps = this.transform.GetChild(2).GetComponent<Text>();
	}
	
	void Update () 
    {
        fpsAccumulator++;
        if(Time.realtimeSinceStartup > fpsNextPeriod)
        {
            currentFps = (int)(fpsAccumulator / fpsPeriod);
            fpsAccumulator = 0;
            fpsNextPeriod += fpsPeriod;
            TextFps.text = string.Format("{0} FPS", currentFps);
        }

        if (Input.GetKeyDown(KeyCode.F12))
        {
            Fps.SetActive(!Fps.activeSelf);

        }
        
        //Debug.Log(this.gameObject.activeSelf);

	}
}
