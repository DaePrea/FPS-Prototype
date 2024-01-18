using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHealth : MonoBehaviour
{
    [SerializeField] float hP = 4f;

    public void TakeDamage(float damage)
    {
        hP -= damage;
        print(hP);

        if (hP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
