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

  



}
