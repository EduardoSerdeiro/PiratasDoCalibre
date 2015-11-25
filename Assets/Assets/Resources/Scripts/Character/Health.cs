using UnityEngine;
using System.Collections;
public class Health : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;

    [SerializeField]private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        
    }


    void Update()
    {
        

    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }

    }

    public float GetCurrHealth()
    {
        return currentHealth;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            TakeDamage(Bullet.damageBullet);
            //Debug.Log("Recebeu dano da bala");

        }

   
    }

   
}
