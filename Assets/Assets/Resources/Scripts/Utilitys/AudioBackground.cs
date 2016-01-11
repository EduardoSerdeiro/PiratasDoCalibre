using UnityEngine;
using System.Collections;

public class AudioBackground : MonoBehaviour
{


	void Start () {

        if(Application.productName != "MainScene")
            DontDestroyOnLoad(this.gameObject);

	}
	
	
}
