using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] float hP = 100f;
    float damage = 3f;

    public void TakeDamage(float damage)
    {
        //if player gets killed by enemies the game over screen will appear
        hP -= damage;
        print("being hurt");
        if (hP <= 0)
        {
            GetComponent<DeathHandle>().DeathHandled();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //collisions for the bullets hitting the player
        if(other.tag == "Bullet")
        {
            TakeDamage(damage);
            Destroy(other.gameObject);
        }
    }


}
