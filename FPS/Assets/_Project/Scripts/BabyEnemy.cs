using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyEnemy : MonoBehaviour, IDamageable
{

    public float health = 100f;
    
    public void TakeDamage(float damage)
    {
        health -= damage;

        if(health <= 0f)
        {
            Debug.Log("Arghhhhhhhh");
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
