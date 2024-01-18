using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float chaseRange = 5f;
    float distanceToTarget;
    float turnSpeed = 5f;
    
    [SerializeField] Transform playerTarget;
    NavMeshAgent nMA;
    Animator anim;

    bool isAggro = false;

    void Start()
    {
        nMA = GetComponent<NavMeshAgent>();   
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(playerTarget.position, transform.position);

        if (isAggro)
        {
            EngageTarget();
        }

        else if(distanceToTarget <= chaseRange)
        {
            isAggro = true;
        }

    }

    private void EngageTarget()
    {
        FaceTarget();

        if(distanceToTarget >= nMA.stoppingDistance)
        {
            anim.SetTrigger("isMoving");
            nMA.SetDestination(playerTarget.position);
        }

        if(distanceToTarget <= nMA.stoppingDistance)
        {
            anim.SetBool("isAttacking", false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    void FaceTarget()
    {
        Vector3 direction = (playerTarget.position - transform.position).normalized;
        Quaternion angleToTurn = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, angleToTurn, Time.deltaTime * turnSpeed);
    }
}
