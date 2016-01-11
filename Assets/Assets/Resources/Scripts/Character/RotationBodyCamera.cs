using UnityEngine;
using System.Collections;

public class RotationBodyCamera : MonoBehaviour {


	void Start () {


	}
	
	void Update () {

        float xRot = Camera.main.transform.localEulerAngles.x;
        this.transform.localEulerAngles = new Vector3(xRot, 0, 0);

	}

    void LateUpdate()
    {
       
       
        
        
    }
}
