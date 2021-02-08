using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelector : MonoBehaviour
{
    public int weaponSelected = 0;

    private List<GameObject> selectableWeapons;
    
    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (weaponSelected >= selectableWeapons.Count - 1)
                weaponSelected = 0;
            else
                weaponSelected++;

            SelectWeapon();
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (weaponSelected <= 0f)
                weaponSelected = selectableWeapons.Count - 1;
            else
                weaponSelected--;

            SelectWeapon();
        }
    }

    void SelectWeapon()
    {
        selectableWeapons = new List<GameObject>();

        foreach (Transform t in transform)
        {
            WeaponBase weaponBase = t.GetComponent<WeaponBase>();

            if(weaponBase != null && weaponBase.weaponInInventory == true)
            {
                selectableWeapons.Add(t.gameObject);
            }
        }

        for (int i = 0; i < selectableWeapons.Count; i++)
        {
            if(i == weaponSelected)
            {
                selectableWeapons[i].SetActive(true);
            }
            else
            {
                selectableWeapons[i].SetActive(false);
            }
        }
    }
}
