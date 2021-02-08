using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    [Header("Weapon Base Settings")]
    public bool weaponInInventory;

    public abstract void Shoot();

    public abstract IEnumerator Reload();
}
