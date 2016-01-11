using UnityEngine;
using System.Collections;

public class CharacterInputAnimation : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {

        if (Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<Animator>().SetBool("Run", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            GetComponent<Animator>().SetBool("Run", false);
        }
	}
}
