﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAndThrow : MonoBehaviour
{
    [Header("Throwables")]
    public GameObject throwObject;
    public float throwForce = 300f;
    public Transform throwFromHere;
    public int numberOfBabies = 69;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightControl) && numberOfBabies > 0)
        {
            numberOfBabies--;
            if (numberOfBabies < 0)
                numberOfBabies = 0;

            GameObject baby = Instantiate(throwObject, throwFromHere.position, throwFromHere.rotation);
            baby.GetComponent<Rigidbody>().AddForce(throwFromHere.forward * throwForce, ForceMode.Impulse);
        }
    }
}