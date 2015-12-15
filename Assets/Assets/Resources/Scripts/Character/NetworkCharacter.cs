using UnityEngine;
using System.Collections;
//using System.Threading;

public class NetworkCharacter : Photon.MonoBehaviour {

   // private System.Threading.Thread enviar = null;
   // private System.Threading.Thread receber = null;

   // PhotonStream stream;
    CharacterController cc;

    private Vector3 corretPlayerPos ;
    private Quaternion corretPlayerRot ;

    public Vector3 direction = Vector3.zero;

    void Start()
    {
        cc = new CharacterController();
       // enviar = new Thread(EnviarDadosPlayer);
       // receber = new Thread(ReceberDadosPlayer);
        
    }
	
    

	void FixedUpdate () {

        if (!photonView.isMine)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, this.corretPlayerPos, Time.deltaTime * 2);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, this.corretPlayerRot, Time.deltaTime * 2);

        }
        else
        {
            //Vector3 dist = direction * 10 * Time.deltaTime;
            //dist.y = 10 * Time.deltaTime;
            //cc.Move(dist);
        }
      
	}

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
       
        if (stream.isWriting)
        {
            stream.SendNext(this.transform);
            stream.SendNext(this.transform.rotation);

              //enviar.Start();
        }
        else
        {
            
            this.corretPlayerPos = (Vector3)stream.ReceiveNext();
            this.corretPlayerRot = (Quaternion)stream.ReceiveNext();
            //receber.Start();
  
        }

       
    }

    //public void EnviarDadosPlayer()
    //{

    //    stream.SendNext(this.transform);
    //    stream.SendNext(this.transform.rotation);

    //}

    //public void ReceberDadosPlayer()
    //{

    //    this.corretPlayerPos = (Vector3)stream.ReceiveNext();
    //    this.corretPlayerRot = (Quaternion)stream.ReceiveNext();

    //}


   
}
