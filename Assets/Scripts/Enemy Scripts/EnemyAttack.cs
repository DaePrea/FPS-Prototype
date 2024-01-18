using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] float damage = 20f;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player")
        {

            Destroy(gameObject);
        }

    }
}
