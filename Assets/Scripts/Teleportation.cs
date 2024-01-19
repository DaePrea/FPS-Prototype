using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    public GameObject Player;
    public GameObject TeleportThere;

    private void OnTriggerEnter(Collider collision)
    {
        //brings the player to a set location
        if (collision.gameObject.CompareTag("Teleporter"))
        {
            Player.transform.position = TeleportThere.transform.position;
        }
    }
}
