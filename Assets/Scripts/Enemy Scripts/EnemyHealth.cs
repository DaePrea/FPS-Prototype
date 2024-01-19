using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hP = 6f;
    
    public void TakeDamage(float damage)
    {
        hP -= damage;
        print(hP);

        //if health is less than or equals to 0 destroy object
        if(hP<=0)
        {
            Destroy(gameObject);
        }
    }
}
