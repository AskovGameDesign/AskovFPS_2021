using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAndThrow : MonoBehaviour
{
    [Header("Throwables")]
    public GameObject throwObject;
    public float throwForce = 300f;
    public Transform throwFromHere;
    public int numberOfBabies = 69;
    public AudioClip throwSound;

    [Header("Projectile")]
    public float projectileDamage = 5f;
    public float projectileRange = 200f;
    public float fireRate = 0.5f;
    private Camera playerCamera;
    private float timeSinceLastShot;
    public AudioClip shootSound;

    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && numberOfBabies > 0)
        {
            numberOfBabies--;
            if (numberOfBabies < 0)
                numberOfBabies = 0;

            if(audio && throwSound)
            {
                audio.PlayOneShot(throwSound);
            }

            GameObject baby = Instantiate(throwObject, throwFromHere.position, Quaternion.Euler(Random.value * 360, Random.value * 360,Random.value * 360));
            baby.GetComponent<Rigidbody>().AddForce(throwFromHere.forward * throwForce, ForceMode.Impulse);
        }

        if(Input.GetMouseButtonDown(0))
        {
            Shoot();

            if (audio && shootSound)
                audio.PlayOneShot(shootSound);
        }

        timeSinceLastShot += Time.deltaTime;
    }

    void Shoot()
    {
        if(timeSinceLastShot >= fireRate)
        {
            Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0f));

            if(Physics.Raycast(ray, out RaycastHit hit, projectileRange))
            {
                if(hit.collider.GetComponent<IDamageable>() != null)
                {
                    hit.collider.GetComponent<IDamageable>().TakeDamage(projectileDamage);
                }
            }

            timeSinceLastShot = 0f;
        }
    }
}
