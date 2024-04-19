using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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

    public int minRange = 5;
    public int maxRange = 20;

    public int timeBetweenSpawningCTR;

    public TMP_Text waveText;
    public int totalEnemies;
    public TMP_Text enemiesLeftText;
    public TMP_Text gameStatusText;
    public GameObject gameStatusScreen;
    public GameObject debugUI;
    public TMP_Text skipWaveText;
    public GameObject gameUI;

    public ParticleSystem particlePrefab;
    private GameObject instantiatedParticle;

    private bool skippingWave;
    private bool debugToggle;


    IEnumerator TimeBetweenWaves() // Set Time Between Waves
    {
        waveText.gameObject.SetActive(true);
        enemiesLeftText.gameObject.SetActive(false);
        waveText.text = "Wave " + (currentWave + 1);

        yield return new WaitForSeconds(5);
        enemiesLeftText.gameObject.SetActive(true);
        enemiesLeftText.text = "Eggs Left: " + totalEnemies;

        SpawnWave();
    }

    IEnumerator TimeBetweenSpawning(int i) // Make Enemies Not Spawn All At The Same Time
    {
        if (timeBetweenSpawningCTR > 1)
        {
            int randomNumber = Random.Range(5, 10);
            // Debug.Log("Current Wave: " + currentWave);
            if (currentWave > 3)
            {
                randomNumber = Random.Range(15, 30);
            }
            // Debug.Log("Random Number: " + randomNumber);
            yield return new WaitForSeconds(randomNumber);
        }

        if (timeBetweenSpawningCTR + 1 == waves[currentWave].GetMonsterSpawnList().Length)
        {
            skippingWave = true;
            skipWaveText.gameObject.SetActive(true);
        }
        SpawnEgg(i);
    }

    // Start is called before the first frame update
    void Start()
    {
        debugUI.gameObject.SetActive(false);
        skipWaveText.gameObject.SetActive(false);

        StartCoroutine(TimeBetweenWaves());
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = player.position; // Make Spawner Be At Player Location
        //Debug.Log(waves[currentWave].GetMonsterSpawnList().Length);

        // Press TAB when prompted in the Debug UI to Skip Waves
        if (Input.GetKeyDown(KeyCode.Tab) && skippingWave && debugToggle)
        {
            SkipWave();
        }

        if (currentWave < 5)
        {
            totalEnemies = waves[currentWave].GetMonsterSpawnList().Length;
        }

        enemiesLeftText.text = "Eggs Left: " + (totalEnemies - enemiesKilled);

        if (currentWave == 5)
        {
            gameStatusScreen.gameObject.SetActive(true);
            gameStatusText.text = "YOU WIN!";
            gameStatusText.color = Color.green;
            gameUI.gameObject.SetActive(false);
        }
        else if (enemiesKilled == waves[currentWave].GetMonsterSpawnList().Length && currentWave < waves.Length)
        {
            // Debug.Log("Wave " + (currentWave + 1) + " complete!");
            enemiesKilled = 0;
            currentWave++;
            StartCoroutine(TimeBetweenWaves());
        }


        #region Wave System Cheat Codes
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            if (Input.GetKeyDown(KeyCode.Period))
            {
                debugUI.gameObject.SetActive(true);
                debugToggle = true;
            }
            else if (Input.GetKeyDown(KeyCode.Comma))
            {
                debugUI.gameObject.SetActive(false);
                debugToggle = false;
            }
        }
        #endregion

    }

    void SpawnWave() // Spawn Wave
    {
        timeBetweenSpawningCTR = 0;
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
        timeBetweenSpawningCTR += 1;
        if (currentWave < 5)
        {
            Vector3 SpawnLoc = FindSpawnLoc();

            instantiatedParticle = Instantiate(particlePrefab, SpawnLoc, Quaternion.identity).gameObject;
            Destroy(instantiatedParticle, 0.5f);

            Instantiate(waves[currentWave].GetMonsterSpawnList()[i], SpawnLoc, Quaternion.identity);
        }
    }

    Vector3 FindSpawnLoc() // Find Random Spawn Locaiton
    {
        Vector3 SpawnPos;

        float randPos = Random.Range(1, 5);
        float xLoc = 0;
        float zLoc = 0;

        if (randPos == 1)
        {
            xLoc = Random.Range(minRange, maxRange) + transform.position.x;
            zLoc = Random.Range(minRange, maxRange) + transform.position.z;
        }
        else if (randPos == 2)
        {
            xLoc = Random.Range(-minRange, -maxRange) + transform.position.x;
            zLoc = Random.Range(-minRange, -maxRange) + transform.position.z;
        }
        else if (randPos == 3)
        {
            xLoc = Random.Range(-minRange, -maxRange) + transform.position.x;
            zLoc = Random.Range(minRange, maxRange) + transform.position.z;
        }
        else
        {
            xLoc = Random.Range(minRange, maxRange) + transform.position.x;
            zLoc = Random.Range(-minRange, -maxRange) + transform.position.z;
        }

        // float yLoc = transform.position.y;
        float yLoc = 25.25f;

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


    public void SkipWave()
    {
        Debug.Log("Skipping Wave " + (currentWave + 1));
        enemiesKilled = waves[currentWave].GetMonsterSpawnList().Length;

        // Kill Nearby Eggs
        float destroyDistance = 1000f;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            // Destroy Eggs Near Player
            float distanceToPlayer = Vector3.Distance(enemy.transform.position, player.position);
            if (distanceToPlayer <= destroyDistance)
            {
                Destroy(enemy);
            }
        }
        skipWaveText.gameObject.SetActive(false);
        skippingWave = false;
    }

}
