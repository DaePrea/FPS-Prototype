using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appear : MonoBehaviour
{
    public GameObject Player;
    public GameObject AppearHere;


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Appear"))
        {
            Player.transform.position = AppearHere.transform.position;
        }

    }
}
