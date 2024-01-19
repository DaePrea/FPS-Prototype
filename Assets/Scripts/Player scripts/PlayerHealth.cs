using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] float hP = 100f;
    float damage = 3f;

    public void TakeDamage(float damage)
    {
        hP -= damage;
        print("being hurt");
        if (hP <= 0)
        {
            GetComponent<DeathHandle>().DeathHandled();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Bullet")
        {
            TakeDamage(damage);
            Destroy(other.gameObject);
        }
    }


}
