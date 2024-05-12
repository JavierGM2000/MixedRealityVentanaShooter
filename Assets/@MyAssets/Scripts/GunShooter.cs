using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooter : MonoBehaviour
{
    public GameObject bulletPref;
    public GameObject shootParticles;
    public Transform muzzle;

    public float shootSpeed;
    public float shootDelay;

    private float counter;

    public AudioSource SoundSource;
    public AudioClip shootSoundSource;


    // Start is called before the first frame update
    void Start()
    {
        SoundSource = GameObject.FindGameObjectWithTag("GameManager").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        shoot(); //de prueba, luego se quita
    }

    public void shoot()
    {
        if (counter >= shootDelay)
        {
            SoundSource.PlayOneShot(shootSoundSource);
            GameObject bullet = Instantiate(bulletPref, muzzle.position, muzzle.rotation);
            GameObject particles = Instantiate(shootParticles, muzzle.position, muzzle.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(muzzle.forward * shootSpeed, ForceMode.Impulse);

            counter = 0;
        }

    }
}
