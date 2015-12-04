using UnityEngine;
using System.Collections;
public class Health : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;

    [SerializeField]private float currentHealth;

    [SerializeField]
    private float TimeRespawn;

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
        Die();

    }

    private void Die()
    {
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
            NetworkManager nm = GameObject.FindObjectOfType<NetworkManager>();
            nm.respawnTime = TimeRespawn + nm.contMorte;
            GameObject mainCamera = GameObject.Find("Main Camera");
            mainCamera.GetComponent<AudioListener>().enabled = true;
           // nm.RespawnPlayer();
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
           // Debug.Log("Recebeu dano da bala");
        }

   
    }

   
}
