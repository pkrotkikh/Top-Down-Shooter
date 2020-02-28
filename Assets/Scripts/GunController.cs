using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

    public Gun startingWeapon;
    public Transform weaponHold;

    Gun equippedWeapon;

    void Start()
    {
        if(startingWeapon != null) {
        EquipWeapon(startingWeapon);
        }
    }

    public void EquipWeapon(Gun gunToEquip) {
        if(equippedWeapon != null) {
            Destroy(equippedWeapon);
        }
        equippedWeapon = Instantiate(gunToEquip, weaponHold.position, weaponHold.rotation);
        equippedWeapon.transform.parent = weaponHold;
    }

    public void Shoot()
    {
        if(equippedWeapon != null)
        {
            equippedWeapon.Shoot();
        }
    }

}
