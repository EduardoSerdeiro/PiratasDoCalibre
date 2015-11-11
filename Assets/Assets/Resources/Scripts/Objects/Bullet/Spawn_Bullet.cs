using UnityEngine;
using System.Collections;

public class Spawn_Bullet : MonoBehaviour {

    [Header("Audio Shoot")]
    private AudioSource audioShoot;
    public AudioClip shoot;


  [Header("Arma")]
    [SerializeField]private GameObject bulletPrefab;

  [SerializeField]private int QuantiMuni = 5;
  [SerializeField]private int muniArma = 1;

    [SerializeField]
    private float cooldown;
    private float timeCurrShoot;

   


	void Start () {
        audioShoot = GetComponent<AudioSource>();
        timeCurrShoot = cooldown;
	}
	
	void FixedUpdate () {

        timeCurrShoot += Time.fixedDeltaTime;

        if (Input.GetMouseButtonDown(0) && timeCurrShoot >= cooldown && muniArma > 0)
        {
            Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
            timeCurrShoot = 0;
            muniArma--;
            audioShoot.PlayOneShot(shoot);
        }

        if (Input.GetKeyDown(KeyCode.R) && QuantiMuni>0 && muniArma< 1)
        {
            muniArma++;
            QuantiMuni--;
        }

	}
}
