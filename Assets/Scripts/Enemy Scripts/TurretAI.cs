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

    [SerializeField] Transform playerTarget;
    Animator anim;

    bool isAggro = false;

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
    }

    private void EngageTarget()
    {
        FaceTarget();

        if(distanceToTarget >= 5f)
        {
            anim.SetTrigger("isAiming");   
        }
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
