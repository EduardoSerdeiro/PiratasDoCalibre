using UnityEngine;
using System.Collections;
using System.Threading;

public class NetworkCharacter : Photon.MonoBehaviour {

    private System.Threading.Thread enviar = null;
    private System.Threading.Thread receber = null;

    PhotonStream stream;

    private Vector3 corretPlayerPos = Vector3.zero;
    private Quaternion corretPlayerRot = Quaternion.identity;


    void Start()
    {
        enviar = new Thread(EnviarDadosPlayer);
        receber = new Thread(ReceberDadosPlayer);
        

    }
	
	void FixedUpdate () {

        if (!photonView.isMine)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, this.corretPlayerPos, Time.deltaTime * 5);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, this.corretPlayerRot, Time.deltaTime * 5);

        }


	}

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
       
        if (stream.isWriting)
        {
            enviar.Start();
            System.Threading.Thread.Sleep(5);
            Debug.Log("Enviando dados");
        }

        if (!stream.isWriting)
        {
            receber.Start();
            System.Threading.Thread.Sleep(5);
            Debug.Log("Recebendo Dados");
        }

       
    }

    public void EnviarDadosPlayer()
    {

        stream.SendNext(this.transform);
        stream.SendNext(this.transform.rotation);

    }

    public void ReceberDadosPlayer()
    {
       
            this.corretPlayerPos = (Vector3)stream.ReceiveNext();
            this.corretPlayerRot = (Quaternion)stream.ReceiveNext();

    }


   
}
