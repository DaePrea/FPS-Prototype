using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            print("picked up pistol");
            Destroy(gameObject);
        }
    }
}
