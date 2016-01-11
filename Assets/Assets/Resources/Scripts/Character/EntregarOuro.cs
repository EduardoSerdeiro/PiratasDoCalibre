using UnityEngine;
using System.Collections;

public class EntregarOuro : MonoBehaviour {

    MainSceneCtrlInter mainSceneInter;
	void Start ()
    {
        mainSceneInter = new MainSceneCtrlInter();
	}
	
	void Update () 
    {
	
	}

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            if(other.gameObject.GetComponent<PegarOuro>().GetPegouOuro() && mainSceneInter.GetIdTeam() == 1 && this.gameObject.tag== "BoteRed")
            {
                // Ouro pro time++
                Debug.Log("Ouro Entregue Red");
                other.gameObject.GetComponent<PegarOuro>().SetPegouOuro(false);
            }
            else if (other.gameObject.GetComponent<PegarOuro>().GetPegouOuro() && mainSceneInter.GetIdTeam() == 2 && this.gameObject.tag == "BoteBlue")
            {
                // Ouro pro time++
                Debug.Log("Ouro Entregue Blue");
                other.gameObject.GetComponent<PegarOuro>().SetPegouOuro(false);
            }


        }

    }

}
