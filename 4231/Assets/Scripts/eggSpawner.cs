using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eggSpawner : MonoBehaviour
{
    [System.Serializable]

    public class WaveContent
    {
        [SerializeField][NonReorderable] GameObject[] eggSpawner;

        public GameObject[] GetMonsterSpawnList()
        {
            return eggSpawner;
        }
    }

    [SerializeField][NonReorderable] WaveContent[] waves;
    public int currentWave = 0;
    float spawnRange = 10;
    public int enemiesKilled = 0;
    public Transform player;

    IEnumerator TimeBetweenWaves() // Set Time Between Waves
    {
        yield return new WaitForSeconds(5);
        SpawnWave();
    }

    IEnumerator TimeBetweenSpawning(int i) // Make Enemies Not Spawn All At The Same Time
    {
        int randomNumber = Random.Range(5, 10);
        yield return new WaitForSeconds(randomNumber);
        SpawnEgg(i);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimeBetweenWaves());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position; // Make Spawner Be At Player Location

        if (currentWave == 5)
        {
            Debug.Log("You Did It!");
        }
        else if (enemiesKilled == waves[currentWave].GetMonsterSpawnList().Length && currentWave < waves.Length)
        {
            Debug.Log("Wave " + (currentWave + 1) + " complete!");
            enemiesKilled = 0;
            currentWave++;
            StartCoroutine(TimeBetweenWaves());
        }
    }

    void SpawnWave() // Spawn Wave
    {
        if (currentWave < waves.Length)
        {
            for (int i = 0; i < waves[currentWave].GetMonsterSpawnList().Length; i++)
            {
                StartCoroutine(TimeBetweenSpawning(i));
            }
        }
    }

    void SpawnEgg(int i) // Spawn Individual Egg
    {
        Instantiate(waves[currentWave].GetMonsterSpawnList()[i], FindSpawnLoc(), Quaternion.identity);
    }

    Vector3 FindSpawnLoc() // Find Random Spawn Locaiton
    {
        Vector3 SpawnPos;

        float randPos = Random.Range(1, 5);
        float xLoc = 0;
        float zLoc = 0;

        if (randPos == 1)
        {
            xLoc = Random.Range(5, 20) + transform.position.x;
            zLoc = Random.Range(5, 20) + transform.position.z;
        }
        else if (randPos == 2)
        {
            xLoc = Random.Range(-5, -20) + transform.position.x;
            zLoc = Random.Range(-5, -20) + transform.position.z;
        }
        else if (randPos == 3)
        {
            xLoc = Random.Range(-5, -20) + transform.position.x;
            zLoc = Random.Range(5, 20) + transform.position.z;
        }
        else
        {
            xLoc = Random.Range(5, 20) + transform.position.x;
            zLoc = Random.Range(-5, -20) + transform.position.z;
        }

        // float yLoc = transform.position.y;
        float yLoc = 1f;

        SpawnPos = new Vector3(xLoc, yLoc, zLoc);

        if (Physics.Raycast(SpawnPos, Vector3.down, 5))
        {
            return SpawnPos;
        }
        else
        {
            return FindSpawnLoc();
        }
    }
}
