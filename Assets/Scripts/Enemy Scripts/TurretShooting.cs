using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TurretShooting : MonoBehaviour
{
    public Transform player;

    public float timeBetweenAttacks;
    bool alreadyAttacked;

    public float sightRange, attackRange;
    public bool playerInSight, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
    }

}
