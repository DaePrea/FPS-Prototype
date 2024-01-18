using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    public GameObject Player;
    public GameObject TeleportThere;
    

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Teleporter"))
        {
            Player.transform.position = TeleportThere.transform.position;
        }
        
    }
}
