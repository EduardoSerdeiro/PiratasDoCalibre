using UnityEngine;
using System.Collections;


public class Bullet : MonoBehaviour
{
    Health health;
    private Rigidbody rigidbody;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float maxSegLife = 3.0f;

   public static int damageBullet = 34;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        rigidbody.velocity = transform.forward * speed;
        Destroy(this.gameObject, maxSegLife);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Bala no jogador");
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
            Debug.Log("Colidiu com algum objeto do mapa");
        }


    }

}
