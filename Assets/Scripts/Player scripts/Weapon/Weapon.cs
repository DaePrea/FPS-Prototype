using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    //parameters
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 20f;
    [SerializeField] float coolDownTimer = 3f;


    //cached refs
    [SerializeField] Camera playerCam;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitVFX;

    bool canShoot = true;

    private void OnEnable()
    {
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && canShoot)
        {
            StartCoroutine(Shoot());
        }
        
    }

    private IEnumerator Shoot()
    {
        canShoot = false;
 
            ProcessRayCast();
            PlayMuzzleFlash();

        yield return new WaitForSeconds(coolDownTimer);
        canShoot = true;
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();  
    }

    private void ProcessRayCast()
    {
        RaycastHit thingWeHit;

        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out thingWeHit, range))
        {
            EnemyHealth target = thingWeHit.transform.GetComponent<EnemyHealth>();
            CreateHitVFX(thingWeHit);
            if (target == null) { return; }
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private void CreateHitVFX(RaycastHit thingWeHit)
    {
        GameObject impact = Instantiate(hitVFX, thingWeHit.point, Quaternion.identity);
        Destroy(impact, 0.1f);
    }
}
