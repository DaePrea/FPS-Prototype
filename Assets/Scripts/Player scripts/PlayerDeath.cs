using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter(Collider collision)
    {
        //determines if the player has collided with the death barrier
        if (collision.gameObject.CompareTag("Death"))
        {
            GetComponent<DeathHandle>().DeathHandled();
        }
        
    }
}
