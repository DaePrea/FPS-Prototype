using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickups : MonoBehaviour
{
    [SerializeField] GameObject Weapons;
    [SerializeField] WeaponSwitcher weaponSwitcher;
    [SerializeField] Transform newPos;

    Collider col;


    void Start()
    {
        col = GetComponent<BoxCollider>();   
    }

    private void OnTriggerEnter(Collider other)
    {
        //makes the object a child of the weapon switcher object
        gameObject.transform.parent = Weapons.transform;
        weaponSwitcher.enabled = true;
        PositionTransfer();
    }

    private void PositionTransfer()
    {
        //changes the position of the object so it is on the player
        gameObject.transform.position = newPos.transform.position;
        gameObject.transform.rotation = newPos.transform.rotation;
        col.enabled = false;
        GetComponent<WeaponPickups>().enabled = false;
    }
}
