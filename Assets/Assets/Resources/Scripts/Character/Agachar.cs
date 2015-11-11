using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
public class Agachar : MonoBehaviour
{

    private CharacterController characterController;

    [SerializeField]private float speedAgachado;

    private float escalaPlayer;
    

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        escalaPlayer = GetComponent<CharacterController>().height / 2;
        speedAgachado = (GetComponent<FirstPersonController>().GetWalkSpeed() / 2);//2.5f; //metade da velocidade de walk speed;
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.LeftControl))
        {
           // characterController.height = escalaPlayer;
            characterController.height = Mathf.Lerp(characterController.height, escalaPlayer, 10 * Time.deltaTime);
            GetComponent<FirstPersonController>().SetWalkSpeed(speedAgachado);
            GetComponent<FirstPersonController>().SetRunSpeed(speedAgachado);
            //FPS_Controlador.m_UseFovKick = false;

        }
        else if (!Input.GetKey(KeyCode.LeftControl))
        {
           // characterController.height = escalaPlayer * 2;
            characterController.height = Mathf.Lerp(characterController.height, escalaPlayer*2, 10 * Time.deltaTime);
            GetComponent<FirstPersonController>().SetWalkSpeed(speedAgachado*2);
            GetComponent<FirstPersonController>().SetRunSpeed(speedAgachado* 4);
        }
    }
}
