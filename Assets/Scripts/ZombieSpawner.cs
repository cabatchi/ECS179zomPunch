using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject zombiePrefab;
    [SerializeField]
    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        // Call the method to start spawning zombies
        StartCoroutine(SpawnZombie());
    }

    // Coroutine to spawn zombies
    IEnumerator SpawnZombie()
    {
        while (true)
        {
            // Wait for a random time between 1 to 10 seconds
            float spawnDelay = Random.Range(1f, 10f);
            yield return new WaitForSeconds(spawnDelay);

            // Spawn the zombie at the spawn point
            if (zombiePrefab != null) 
            {
                Instantiate(zombiePrefab, spawnPoint.position, Quaternion.identity);
            }
        }
    }

    // void Update()
    // {
    //     if (Input.GetButtonDown("Fire1"))
    //     {
    //         SpawnZombie();
    //     }
    // }

    // void SpawnZombie()
    // {
    //     if (zombiePrefab != null)
    //     {
    //         Instantiate(zombiePrefab, transform.position, transform.rotation);
    //     }
    // }
}
