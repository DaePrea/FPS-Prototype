using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] float hP = 100f;


    public void TakeDamage(float damage)
    {
        hP -= damage;
        print("being hurt");
        if (hP <= 0)
        {
            GetComponent<DeathHandle>().DeathHandled();
        }
    }
}
