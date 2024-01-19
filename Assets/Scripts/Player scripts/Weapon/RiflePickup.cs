using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiflePickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //lets you pick up the rifle
        if (other.gameObject.tag == "Player")
        {
            print("picked up rifle");
            Destroy(gameObject);
        }

    }
}