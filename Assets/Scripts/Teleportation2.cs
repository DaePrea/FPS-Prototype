using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation2 : MonoBehaviour
{
    public GameObject Player;
    public GameObject TeleportHere;


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Teleporter 2"))
        {
            Player.transform.position = TeleportHere.transform.position;
        }

    }
}
