using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    public GameObject Player;
    public GameObject TeleportHere;
    

    private void OnTriggerEnter(Collider collision)
    {
       
            Player.transform.position = TeleportHere.transform.position;
        
    }
}
