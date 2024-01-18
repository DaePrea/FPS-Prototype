using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] float raycastRange = 100f;
    [SerializeField] float damage = 2f;

    [SerializeField] Camera playerCam;

    void Start()
    {
        
    }

   
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        ProcessRaycast();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;

        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, raycastRange))
        {
            WalkerHealth target = hit.transform.GetComponent<WalkerHealth>();
            target.TakeDamage(damage);
        }

        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, raycastRange))
        {
            TurretHealth target = hit.transform.GetComponent<TurretHealth>();
            target.TakeDamage(damage);
        }
    

        else { return; }
    }
}
