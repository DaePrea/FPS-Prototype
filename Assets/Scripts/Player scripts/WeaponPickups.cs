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

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        gameObject.transform.parent = Weapons.transform;
        weaponSwitcher.enabled = true;
        PositionTransfer();
    }

    private void PositionTransfer()
    {
        gameObject.transform.position = newPos.transform.position;
        gameObject.transform.rotation = newPos.transform.rotation;
        col.enabled = false;
        GetComponent<WeaponPickups>().enabled = false;
    }
}
