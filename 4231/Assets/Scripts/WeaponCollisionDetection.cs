using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollisionDetection : MonoBehaviour
{
    public WeaponController wc;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collide");
        if (other.tag == "Enemy" && wc.isAttacking)
        {
            // Debug.Log("hit");
            other.GetComponent<Animator>().SetTrigger("Hit");
        }
    }
}
