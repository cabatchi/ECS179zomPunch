using System.Collections;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private GameObject zombiePrefab;
    [SerializeField] private GameObject giantZombiePrefab;
    [SerializeField] private GameObject archerZombiePrefab;
    [SerializeField] private GameObject magicZombiePrefab;
    [SerializeField] private Transform spawnPoint;
    public float spawnRate = 1f;
    public float timeBetweenWaves = 3f;
    public static int currentWave = 1; // Static variable to track the current wave

    public float giantZombieProbability = 0.05f; // Probability of spawning a giant zombie
    public float archerZombieProbability = 0.05f; // Probability of spawning an archer zombie
    public float magicZombieProbability = 0.05f; // Probability of spawning a magic zombie

    private bool waveIsDone = false;
    public int remainingZombies = 0;
    public int spawnerType = 0;

    void Start()
    {
        if (!waveIsDone) 
        {
            StartCoroutine(SpawnZombie());
        }
    }

   IEnumerator SpawnZombie()
    {
        while (true)
        {
            for (int i = 0; i < currentWave; i++) 
            {
                SpawnSingleZombie();
                yield return new WaitForSeconds(spawnRate);
            }

            yield return new WaitForSeconds(timeBetweenWaves);

            while (remainingZombies > 0)
            {
                yield return null;
            }

            waveIsDone = true;

            while (!Input.GetKeyDown(KeyCode.K))
            {
                yield return null;
            }
            
            if (spawnerType == 1) 
            {
                waveIsDone = false;
                currentWave++;
                Debug.Log("Wave Updated to " + currentWave);
            }
        }
    }


    void Update() 
    {
        UpdateRemainingZombies();
    }

    void SpawnSingleZombie()
    {
        float randomValue = Random.value;

        if (randomValue < giantZombieProbability)
        {
            SpawnZombieOfType(giantZombiePrefab);
        }
        else if (randomValue < giantZombieProbability + archerZombieProbability)
        {
            SpawnZombieOfType(archerZombiePrefab);
        }
        else if (randomValue < giantZombieProbability + archerZombieProbability + magicZombieProbability)
        {
            SpawnZombieOfType(magicZombiePrefab);
        }
        else
        {
            SpawnZombieOfType(zombiePrefab); // Regular zombie
        }
    }

    void SpawnZombieOfType(GameObject zombieType)
    {
        if (zombieType != null) 
        {
            GameObject zombie = Instantiate(zombieType, spawnPoint.position, Quaternion.identity);
            remainingZombies++;
        }
    }

    void UpdateRemainingZombies()
    {
        // Count zombies by adding all game objects with the "Enemy" tag
        GameObject[] zombies = GameObject.FindGameObjectsWithTag("Enemy");
        remainingZombies = zombies.Length;
    }
}
