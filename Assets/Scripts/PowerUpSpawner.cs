using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    private float timeBetweenChecks = 5.0f;
    private float timer = 0;
    private bool canSpawnPowerUp = true;
    private static GameObject[] powerUps;
    // Update is called once per frame
    void Start()
    {
        powerUps = Resources.LoadAll<GameObject>("Prefabs/PowerUpPickUp");
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeBetweenChecks)
        {
            CheckZombieCount();
            timer = 0;
        }
    }
    private void CheckZombieCount()
    {
        GameObject[] zombies = GameObject.FindGameObjectsWithTag("Enemy");
        if (zombies.Length == 0 && canSpawnPowerUp)
        {
            Debug.Log("Spawning PowerUp");
            SpawnPowerUp();
            canSpawnPowerUp = false;
            StartCoroutine(EnableSpawnWhenNewRoundDetected());
        }
    }

    private void SpawnPowerUp()
    {
        // Spawn a powerup
        int randomInt = Random.Range(0,powerUps.Length);
        GameObject powerUp = Instantiate(powerUps[randomInt]) as GameObject;
        powerUp.transform.position = this.transform.position;
    }

    private IEnumerator EnableSpawnWhenNewRoundDetected()
    {
        while(true)
        {
            yield return new WaitForSeconds(1.0f);
            GameObject[] zombies = GameObject.FindGameObjectsWithTag("Enemy");
            if (zombies.Length > 0)
            {
                canSpawnPowerUp = true;
                break;
            }
        }
    }

}
