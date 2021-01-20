using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyExplode : MonoBehaviour
{
    public GameObject babySplat;
    public int damage = 10;
    public float explosionForce = 500f;
    public float range = 5f;

    void Explosion()
    {
        List<Rigidbody> rigidbodies = new List<Rigidbody>();
        Collider[] colliders = Physics.OverlapSphere(transform.position, range);

        foreach (var coll in colliders)
        {
            Rigidbody rb = coll.transform.root.GetComponentInChildren<Rigidbody>();

            if (!rigidbodies.Contains(rb) && rb != null)
                rigidbodies.Add(rb);
        }

        foreach (var rb in rigidbodies)
        {
            rb.AddExplosionForce(explosionForce, transform.position, range, 2f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(babySplat, transform.position, Quaternion.identity);

        Explosion();

        if(other.transform.root.GetComponent<IDamageable>() != null)
            other.transform.root.GetComponent<IDamageable>().TakeDamage(damage);

        Destroy(gameObject);
    }

}
