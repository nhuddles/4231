using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player; // Reference to the player object
    public float chaseRange = 100f; // Range within which the enemy will start chasing the player
    public float attackRange = 5f; // Range within which the enemy will attack the player
    public float chaseSpeed = 2f; // Speed of chasing
    public float attackDelay = 1f; // Delay between attacks
    public float patrolRadius = 25f; // Radius of the circular patrol path
    public float patrolSpeed = 2f; // Speed of patrolling
    private Vector3[] patrolPoints; // Array of patrol points
    private int currentPatrolPointIndex = 0;
    private Vector3 currentPatrolPoint;
    private float nextAttackTime = 0f;

    #region Egg Variations
    // Texture Changing
    public Material[] materials;

    // Access Bottom
    private GameObject eggBottom;
    private MeshRenderer eggBottomRenderer;

    // Access Top
    private GameObject eggTop;
    private MeshRenderer eggTopRenderer;
    #endregion


    public ParticleSystem particlePrefab;
    private GameObject instantiatedParticle;

    enum State
    {
        Patrolling,
        Chasing,
        Attacking
    }

    private State currentState;

    void Start()
    {
        currentState = State.Patrolling;
        GeneratePatrolPoints();
        currentPatrolPoint = patrolPoints[0];

        #region Access Egg Parts
        eggBottom = transform.Find("bottom/cuboid").gameObject;
        eggBottomRenderer = eggBottom.GetComponent<MeshRenderer>();

        eggTop = transform.Find("top/cuboid_1").gameObject;
        eggTopRenderer = eggTop.GetComponent<MeshRenderer>();
        #endregion

        #region Randomize Egg Colors
        int randomInteger = Random.Range(0, 3);
        changeEgg(randomInteger);
        #endregion
    }


    void Update()
    {

        #region Minor Quality of Life Egg Changes
        
        // Prevent Jumping with the player
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, 25.25f, gameObject.transform.position.z);
        
        // Prevent enemy from moving when dead
        if (gameObject.CompareTag("Dead"))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 25.25f, gameObject.transform.position.z);
            chaseSpeed = 0f;

            StartCoroutine(ParticleAfterDeath());
        }

        // Look at the player
        if (player != null && !gameObject.CompareTag("Dead"))
        {
            transform.rotation = Quaternion.LookRotation(transform.position - player.position);
        }
        #endregion

        // Check the distance between enemy and player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        switch (currentState)
        {
            case State.Patrolling:
                Patrolling();
                // If player is within chase range, start chasing
                if (distanceToPlayer <= chaseRange)
                {
                    currentState = State.Chasing;
                }
                break;
            case State.Chasing:
                Chasing();
                // If player is within attack range, start attacking
                if (distanceToPlayer <= attackRange)
                {
                    currentState = State.Attacking;
                }
                // If player goes out of chase range, resume patrolling
                else if (distanceToPlayer > chaseRange)
                {
                    currentState = State.Patrolling;
                    GeneratePatrolPoints();
                }
                break;
            case State.Attacking:
                Attacking();
                // If player goes out of attack range, resume chasing
                if (distanceToPlayer > attackRange)
                {
                    currentState = State.Chasing;
                }
                break;
        }
    }

    void Patrolling()
    {
        // Move towards current patrol point
        transform.position = Vector3.MoveTowards(transform.position, currentPatrolPoint, patrolSpeed * Time.deltaTime);

        // Check if reached the patrol point
        if (Vector3.Distance(transform.position, currentPatrolPoint) < 0.1f)
        {
            // Move to next patrol point
            currentPatrolPointIndex = (currentPatrolPointIndex + 1) % patrolPoints.Length;
            currentPatrolPoint = patrolPoints[currentPatrolPointIndex];
        }
    }

    // Generate patrol points in a circle around the starting position
    void GeneratePatrolPoints()
    {
        int numPoints = 8; // Number of points on the circle
        patrolPoints = new Vector3[numPoints];

        for (int i = 0; i < numPoints; i++)
        {
            float angle = i * Mathf.PI * 2f / numPoints;
            float x = Mathf.Cos(angle) * patrolRadius;
            float z = Mathf.Sin(angle) * patrolRadius;
            patrolPoints[i] = transform.position + new Vector3(x, 0f, z);
        }
    }

    void Chasing()
    {
        // Move towards the player
        transform.position = Vector3.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);
    }

    void Attacking()
    {
        // Attack the player
        if (Time.time >= nextAttackTime)
        {
            // Do attack action here
            // Debug.Log("Enemy attacks!");
            nextAttackTime = Time.time + attackDelay;
        }
    }




    IEnumerator ParticleAfterDeath()
    {
        yield return new WaitForSeconds(0.75f);
        instantiatedParticle = Instantiate(particlePrefab, transform.position, Quaternion.identity).gameObject;
        Destroy(instantiatedParticle, 0.5f);
    }

    public void changeEgg(int index)
    {
        eggBottomRenderer.material = materials[index]; // Change Body
        eggTopRenderer.material = materials[index]; // Change Right Hand
    }

}