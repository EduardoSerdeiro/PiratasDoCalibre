using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    MainSceneCtrlInter mainSceneInter;

    [SerializeField]
    private float maxHealth;

    [SerializeField]private float currentHealth;

    [SerializeField]
    private float TimeRespawn;

   // private GameObject canvas;
    public GameObject BarraVida;

    [Header("Interfaces - Sprites")]
    public Sprite escudoVermelho;
    public Sprite escudoAzul;
    public Sprite carrack;
    public Sprite galleon;
    public Sprite eloise;
    public Sprite betta;

    void Start()
    {
       // canvas = GameObject.Find("Canvas");
        mainSceneInter = new MainSceneCtrlInter();

        BarraVida = GameObject.Find("Canvas").transform.GetChild(9).gameObject;
        BarraVida.SetActive(true);

        if (mainSceneInter.GetIdTeam() == 1 && mainSceneInter.GetId() == 1)
        {
            BarraVida.transform.GetChild(0).GetComponent<Image>().sprite = escudoVermelho;
            BarraVida.transform.GetChild(1).GetComponent<Image>().sprite = carrack;
        }
        else if (mainSceneInter.GetIdTeam() == 2 && mainSceneInter.GetId() == 1)
        {
            BarraVida.transform.GetChild(0).GetComponent<Image>().sprite = escudoAzul;
            BarraVida.transform.GetChild(1).GetComponent<Image>().sprite = galleon;
        }
        else if (mainSceneInter.GetIdTeam() == 1 && mainSceneInter.GetId() == 2)
        {
            BarraVida.transform.GetChild(0).GetComponent<Image>().sprite = escudoVermelho;
            BarraVida.transform.GetChild(1).GetComponent<Image>().sprite = eloise;
        }
        else if (mainSceneInter.GetIdTeam() == 2 && mainSceneInter.GetId() == 2)
        {
            BarraVida.transform.GetChild(0).GetComponent<Image>().sprite = escudoAzul;
            BarraVida.transform.GetChild(1).GetComponent<Image>().sprite = betta;
        }

        currentHealth = maxHealth;
        
    }

    void Update()
    {
        BarraVida.transform.GetChild(0).GetComponent<Image>().fillAmount = (currentHealth / 100);
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
            Debug.Log("Recebeu dano da bala");
        }

   
    }

   
}
