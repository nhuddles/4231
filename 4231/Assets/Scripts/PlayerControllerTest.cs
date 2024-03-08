using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTest : MonoBehaviour
{
    public float speed = 5f;

    // Animation Variables
    public Animator animator;
    private int pastAttack = 0;
    private int randomAttack = 1;


    void Start()
    {
   
    }

    void Update()
    {
        // SUPER BASIC player movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        transform.Translate(moveDirection * speed * Time.deltaTime);

        #region Animation Triggering
        
        // Attacking with Left-Click
        if (Input.GetMouseButtonDown(0))
        {
            while (pastAttack == randomAttack) // Ensure there is a different attack animation
            {
                randomAttack = Random.Range(1, 4);
            }
            pastAttack = randomAttack;
            animator.SetInteger("Attack", randomAttack);
            animator.ResetTrigger("Dance");
        }

        // Dancing with Spacebar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Dance");
        }

        // Death with 0
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            // animator.SetBool("Dead", true);
            animator.SetTrigger("Death");
        }

        // Move with movement kety + Dash with movement keys + LShift
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            animator.SetTrigger("Move");
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetTrigger("Dash");
            }
        }
        #endregion

    }

}
