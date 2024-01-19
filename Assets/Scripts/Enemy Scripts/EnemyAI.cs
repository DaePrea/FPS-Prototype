using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float chaseRange = 5f;
    float distanceToTarget = Mathf.Infinity;
    float turnSpeed = 5f;
    
    [SerializeField] Transform playerTarget;
    NavMeshAgent nMA;
    Animator anim;

    bool isAggro = false;

    void Start()
    {
        nMA = GetComponent<NavMeshAgent>();
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

        else if (distanceToTarget <= chaseRange)
        {
            isAggro = true;
        }

    }

    private void EngageTarget()
    {
        FaceTarget();

        if (distanceToTarget >= nMA.stoppingDistance)
        {
            anim.SetTrigger("isMoving");
            anim.SetBool("isAttacking", false);
            nMA.SetDestination(playerTarget.position);
        }

        if (distanceToTarget <= nMA.stoppingDistance)
        {
            anim.SetBool("isAttacking", true);
        }
    }

    private void AtackPlayer()
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        print("attacking poorly");
    }

    private void ChasePlayer()
    {
        GetComponent<Animator>().SetBool("isMoving", true);
        GetComponent<Animator>().SetBool("isAttacking", false);
        nMA.SetDestination(playerTarget.transform.position);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    void FaceTarget()
    {
        //makes the turret face the player
        Vector3 direction = (playerTarget.position - transform.position).normalized;
        Quaternion angleToTurn = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, angleToTurn, Time.deltaTime * turnSpeed);
    }
}
