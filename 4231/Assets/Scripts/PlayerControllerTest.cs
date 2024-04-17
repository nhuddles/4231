using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerControllerTest : MonoBehaviour
{
    public float speed = 5f;
    public int playerState = 0;
    public bool canMove = true;
    public int health;
    public TMP_Text healthText;

    public EnemyAI enemyAI;
    int ctrDeath;

    public GameObject gameOverScreen;
    public GameObject gameUI;
    public TMP_Text gameStatusText;

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
        health = 100;
        ctrDeath = 0;
        gameOverScreen.gameObject.SetActive(false);
        gameUI.gameObject.SetActive(true);

        playerRB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        healthText.text = "Health: " + health;

        // SUPER BASIC player movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (canMove)
        {
            Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
            transform.Translate(moveDirection * speed * Time.deltaTime);
        }

        if (health < 1)
        {
            //animator.SetTrigger("Death");
            gameOver();
        }
        #region Animation Triggering Test
        
        /*// Attacking with Left-Click
        if (Input.GetMouseButtonDown(0))
        {
            while (pastAttack == randomAttack) // Ensure there is a different attack animation
            {
                randomAttack = Random.Range(1, 4);
            }
            pastAttack = randomAttack;
            animator.SetInteger("Attack", randomAttack);
            animator.ResetTrigger("Dance");
        } */

        // Dancing with P
        if (Input.GetKeyDown(KeyCode.P))
        {
            animator.SetTrigger("Dance");
        }

        // Death with 0
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
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
        if ((Input.GetKeyDown(KeyCode.Space) && isOnGround) && canMove)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            animator.SetTrigger("Jump");
        }

        #endregion

        #region Player Cheat Codes
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            if (Input.GetKeyDown(KeyCode.Equals))
            {
                health += 100;
            }
        }
        #endregion

    }

    #region Check if Player Touches Ground or Enemy
    private void OnCollisionEnter(Collision collision)
    {
        // Allow Jumping When Touching Ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }

        // Cause Damage to Player When Colliding With Enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            int ctr = 0;
            playerState = 4;
            health -= 5;
            // Debug.Log("Player hAs been hit :(");
            while (ctr < 50)
            {
                transform.Translate(Vector3.back * 2.5f * Time.deltaTime);
                ctr++;
            }
            StartCoroutine(DamageEffect());
        }

        // Kill Player When Outside Bounds of Table
        if (collision.gameObject.CompareTag("PlayerDead"))
        {
            //animator.SetTrigger("Death");
            gameOver();
        }
    }

    IEnumerator DamageEffect()
    {
        yield return new WaitForSeconds(0.5f);
        playerState = 5;
    }
    #endregion

    private void gameOver()
    {
        // Ensure Death Animation is Only Called Once
        while (ctrDeath == 0)
        {
            animator.SetTrigger("Death");
            ctrDeath = 1;
        }

        // Ensure Health is at 0
        health = 0;

        // Disable Movement
        canMove = false;

        // Kill Nearby Eggs
        float destroyDistance = 1000f;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            // Destroy Eggs Near Player
            float distanceToPlayer = Vector3.Distance(enemy.transform.position, transform.position);
            if (distanceToPlayer <= destroyDistance)
            {
                Destroy(enemy);
            }
        }

        gameStatusText.text = "GAME OVER";
        gameStatusText.color = Color.red;
        gameOverScreen.gameObject.SetActive(true);
        gameUI.gameObject.SetActive(false);
    }


    #region Button Methods
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    #endregion
}
