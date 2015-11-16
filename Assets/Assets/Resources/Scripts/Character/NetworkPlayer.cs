using UnityEngine;
using System.Collections;

public class NetworkPlayer : Photon.MonoBehaviour {

    private Vector3 corretPlayerPos = Vector3.zero;
    private Quaternion corretPlayerRot = Quaternion.identity;

	
	void Update () {

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
            stream.SendNext(this.transform);
            stream.SendNext(this.transform.rotation);
        }
        else
        {
            this.corretPlayerPos = (Vector3)stream.ReceiveNext();
            this.corretPlayerRot = (Quaternion)stream.ReceiveNext();


        }
    }


}
