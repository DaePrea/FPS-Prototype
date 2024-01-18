using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TurretAI : MonoBehaviour
{

    [SerializeField] float attackRange = 5f;
    float distanceToTarget;
    float turnSpeed = 3f;
    [SerializeField] float damage = 2f;

    [SerializeField] Transform playerTarget;
    Animator anim;

    bool isAggro = false;


    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;
    public float health;
    public float sightRange, attackSight;
    public bool playerInSightRange, playerInAttackRange;
    public LayerMask player;

    void Start()
    {
        anim = GetComponent<Animator>();  
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(playerTarget.position, transform.position);

        if (isAggro)
        {
            EngageTarget();
        }

        else if (distanceToTarget <= attackRange)
        {
            isAggro = true;
        }

        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, player);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackSight, player);
        if (playerInAttackRange && playerInSightRange) EngageTarget();
    }



    private void EngageTarget()
    {
        FaceTarget();

        if(distanceToTarget >= 5f)
        {
            anim.SetTrigger("isAiming");   
        }

        if (!alreadyAttacked)
        {
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            Vector3 directionToShoot = (playerTarget.position - transform.position).normalized;
            rb.AddForce(directionToShoot * 96f, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
        
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    void FaceTarget()
    {
        Vector3 direction = (playerTarget.position - transform.position).normalized;
        Quaternion angleToTurn = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, angleToTurn, Time.deltaTime * turnSpeed);
    }
}
