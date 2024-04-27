using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject Sword;
    public bool CanAttack = true;
    public float AttackCooldown = 0.1f;

    public bool isAttacking = false;

    private int pastAttack = 0;
    private int randomAttack = 1;

    public ParticleSystem particlePrefab;
    private GameObject instantiatedParticle;

    public PlayerControllerTest playerCT;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (CanAttack && playerCT.canMove)
            {
                SwordAttack();
            }
        }
    }

    public void SwordAttack()
    {
        isAttacking = true;
        CanAttack = false;
        Animator anim = Sword.GetComponent<Animator>();
        while (pastAttack == randomAttack) // Ensure there is a different attack animation
        {
            randomAttack = Random.Range(1, 4);
        }
        pastAttack = randomAttack;
        anim.SetInteger("Attack", randomAttack);
        anim.ResetTrigger("Dance");

        instantiatedParticle = Instantiate(particlePrefab, transform.position, Quaternion.identity).gameObject;
        instantiatedParticle.transform.parent = transform;
        instantiatedParticle.transform.localRotation = Quaternion.Euler(0f, -315f, 180f);
        Destroy(instantiatedParticle, 1);

        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(AttackCooldown);
        CanAttack = true;
    }

    IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(1.0f);
        isAttacking = false;
    }
}
