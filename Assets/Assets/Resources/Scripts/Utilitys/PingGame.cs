using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PingGame : MonoBehaviour {

    [SerializeField]
    private GameObject Ping;

    private Text TextPing;

	void Start () {

        Ping.SetActive(false);
        TextPing = this.transform.GetChild(3).GetComponent<Text>();

	}
	
	void Update () {

        TextPing.text = "Ping: " + PhotonNetwork.GetPing().ToString();

        if (Input.GetKeyDown(KeyCode.F12))
        {
            Ping.SetActive(!Ping.activeSelf);

        }

	}
}
