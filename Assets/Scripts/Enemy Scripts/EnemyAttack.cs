using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] PlayerHealth playerTarget;
    [SerializeField] float damage = 20f;

    //private void OnTriggerEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        PlayerHealth target = transform.GetComponent<PlayerHealth>();
    //        target.TakeDamage(damage);
    //    }

    //}
}
