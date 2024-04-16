using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.UI;
using TMPro;

public class WeaponCollisionDetection : MonoBehaviour
{
    public WeaponController wc;
    public eggSpawner eg;
    //public TextMeshProUI healthText;
    public TMP_Text m_TextComponent;

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
            // m_TextComponent.text = "Enemies Left: " + eg.totalEnemies;
        }
    }
}