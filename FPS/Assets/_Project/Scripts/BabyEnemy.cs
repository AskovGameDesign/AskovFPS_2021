using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyEnemy : MonoBehaviour, IDamageable
{

    public int health = 100;
    
    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
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
