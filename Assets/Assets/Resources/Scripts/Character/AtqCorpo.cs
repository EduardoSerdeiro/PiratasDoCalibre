using UnityEngine;
using System.Collections;

public class AtqCorpo : MonoBehaviour {

    [Header("Atributos Golpear")]
    [SerializeField]private float damageGolpe;
    [SerializeField]
    private float cooldownGolpe;

    private float timeGolpe;

	void Start () {

        timeGolpe = 0;

	}
	
	void Update () {

        timeGolpe += Time.deltaTime;

	}

    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            if (Input.GetMouseButtonDown(1) && timeGolpe >= cooldownGolpe)
            {
                GameObject inimigo = col.gameObject;
                inimigo.GetComponent<Health>().TakeDamage(damageGolpe);
                timeGolpe = 0;
            }

        }

    }
}
