using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] PlayerHealth playerTarget;
    [SerializeField] float damage = 20f;


    public void Attack()
    {
        playerTarget.TakeDamage(damage);
    }
}
