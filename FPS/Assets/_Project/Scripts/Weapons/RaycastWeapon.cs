using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastWeapon : WeaponBase
{
    [Header("Raycast Weapon Settings")]
    public float fireRate = 1f;
    public float fireRange = 100f;
    public float damage = 15f;
    public AudioClip fireSound;
    public ParticleSystem muzzleFlash;
    public float reloadTime = 1f;
    public int maxAmmoCapacity = 50;
    private int currentAmmo;
    private bool isReloading; 
    public Animator animator;

    private Camera camera;
    private AudioSource audio;
    private float timeSinceLastShoot;

    public override void Shoot()
    {
        if (muzzleFlash)
            muzzleFlash.Play();

        if(Physics.Raycast(camera.transform.position, camera.transform.forward, out RaycastHit hit, fireRange))
        {
            if(hit.transform.root.GetComponentInChildren<IDamageable>() != null)
            {
                hit.transform.root.GetComponentInChildren<IDamageable>().TakeDamage(damage);
            }
        }
        currentAmmo--;
        timeSinceLastShoot = 0f;
    }

    

    // Start is called before the first frame update
    void Start()
    {
        camera = transform.root.GetComponentInChildren<Camera>();

        currentAmmo = maxAmmoCapacity;
    }

    private void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading)
            return;
        
        if(currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
        
        if(Input.GetButtonDown("Fire1") && timeSinceLastShoot >= fireRate )
        {
            Shoot();
        }

        timeSinceLastShoot += Time.deltaTime;
    }

    public override IEnumerator Reload()
    {
        isReloading = true;
        animator.SetBool("Reloading", true);
        yield return new WaitForSeconds(reloadTime);
        animator.SetBool("Reloading", false);
        currentAmmo = maxAmmoCapacity;
        isReloading = false;
    }
}
