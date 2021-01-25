using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticDamage : MonoBehaviour, IDamageable
{
    public float health = 10f;
    public GameObject explosion;

    public void TakeDamage(float damage)
    {
        health -= damage;

        if(health <= 0f)
        {
            if(explosion)
            {
                Instantiate(explosion, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
