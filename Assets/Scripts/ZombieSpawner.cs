using System.Collections;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private GameObject zombiePrefab;
    [SerializeField] private Transform spawnPoint;
    public float spawnRate = 1f;
    public float timebetweenWaves = 3f;
    public static int currentWave = 1; // Static variable to track the current wave

    private bool waveIsDone = true;
    public int remainingZombies = 0;
    public int spawnerType = 0;

    void Start()
    {
        if (waveIsDone) 
        {
            StartCoroutine(SpawnZombie());
        }
    }

    IEnumerator SpawnZombie()
    {
        while (true)
        {
            // Spawn zombies for the current wave
            for (int i = 0; i < currentWave * 3; i++) 
            {
                SpawnSingleZombie();
                yield return new WaitForSeconds(spawnRate);
            }

            // Wait for a while before starting the next wave
            yield return new WaitForSeconds(timebetweenWaves);

            // Check if all zombies are gone
            while (remainingZombies > 0)
            {
                yield return null; // Wait until all zombies are gone
            }

            // Start the next wave
            waveIsDone = true;
            if (spawnerType == 1) 
            {
                currentWave++;
            }
            Debug.Log("Wave Updated to " + currentWave);
        }
    }

    void Update() 
    {
        UpdateRemainingZombies();
    }

    void SpawnSingleZombie()
    {
        if (zombiePrefab != null) 
        {
            GameObject zombie = Instantiate(zombiePrefab, spawnPoint.position, Quaternion.identity);
            // zombie.GetComponent<ZombieToast>().OnDestroyed += OnZombieDestroyed;
            remainingZombies++;
        }
    }

    // void OnZombieDestroyed()
    // {
    //     remainingZombies--;
    // }

    void UpdateRemainingZombies()
    {
        // Count zombies by adding all game objects with the "Enemy" tag
        GameObject[] zombies = GameObject.FindGameObjectsWithTag("Enemy");
        remainingZombies = zombies.Length;
    }
}
