using UnityEngine;
using System.Collections;

public class ScrbWindowControl : MonoBehaviour
{
 
    [SerializeField]private GameObject scoreBoard;

    void Start()
    {
        scoreBoard.SetActive(false);
        
    }

	void Update () {

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            scoreBoard.SetActive(!scoreBoard.activeSelf);
        }
        else if (Input.GetKeyUp(KeyCode.Tab))
        {
            scoreBoard.SetActive(!scoreBoard.activeSelf);
        }
	}

}
