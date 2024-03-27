using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollisionDetection : MonoBehaviour
{
    public WeaponController wc;
    public eggSpawner eg;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collide");
        if (other.tag == "Enemy" && wc.isAttacking)
        {
            // Debug.Log("hit");
            eg.enemiesKilled++;
            other.GetComponent<Animator>().SetTrigger("Hit");
            other.tag = "Dead";
            Destroy(other.gameObject, 1);
        }
    }
}
