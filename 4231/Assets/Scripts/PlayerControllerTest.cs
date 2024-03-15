using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTest : MonoBehaviour
{
    public float speed = 5f;

    #region Animation Variables
    public Animator animator;
    private int pastAttack = 0;
    private int randomAttack = 1;
    #endregion

    #region Jump Variables
    public bool isOnGround = true;
    public float jumpForce = 7f;
    private Rigidbody playerRB;
    #endregion


    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
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

        // Dancing with P
        if (Input.GetKeyDown(KeyCode.P))
        {
            animator.SetTrigger("Dance");
        }

        // Death with 0
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            // animator.SetBool("Dead", true);
            animator.SetTrigger("Death");
        }

        // Move with movement key + Dash with movement keys + LShift
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            animator.SetTrigger("Move");
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetTrigger("Dash");
            }
        }
        #endregion

        #region Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            animator.SetTrigger("Jump");
        }

        #endregion

    }

    #region Check if Player Touches Ground
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
    #endregion

}
