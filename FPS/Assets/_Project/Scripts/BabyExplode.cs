using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyExplode : MonoBehaviour
{
    public GameObject babySplat;
    public float maxDamage = 10f;
    public float explosionForce = 500f;
    public float range = 5f;

    List<Rigidbody> rigidbodies;
    void Explosion()
    {
        rigidbodies = new List<Rigidbody>();
        Collider[] colliders = Physics.OverlapSphere(transform.position, range);

        foreach (var coll in colliders)
        {
            Rigidbody rb = coll.transform.root.GetComponentInChildren<Rigidbody>();

            if (!rigidbodies.Contains(rb) && rb != null)
                rigidbodies.Add(rb);
        }

        foreach (var rb in rigidbodies)
        {
            float dist = Vector3.Distance(transform.position, rb.position);

            float newDamage = Mathf.Lerp(maxDamage, 0f, dist / range);

            if (rb.transform.root.GetComponent<IDamageable>() != null)
                rb.transform.root.GetComponent<IDamageable>().TakeDamage(newDamage);

            rb.AddExplosionForce(explosionForce, transform.position, range, 2f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(babySplat, transform.position, Quaternion.identity);

        Explosion();

        //if(other.transform.root.GetComponent<IDamageable>() != null)
          //  other.transform.root.GetComponent<IDamageable>().TakeDamage(damage);

        Destroy(gameObject);
    }

}
