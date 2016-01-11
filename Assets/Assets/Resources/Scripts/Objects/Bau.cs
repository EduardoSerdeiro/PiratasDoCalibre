using UnityEngine;
using System.Collections;

public class Bau : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () 
    {
	
	}

    void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PegarOuro>().SetPertoBau(true);
            
        }
      
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PegarOuro>().SetPertoBau(false);
        }
    }

    

}
