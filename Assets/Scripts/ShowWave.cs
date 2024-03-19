using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowWave : MonoBehaviour
{
    public TMP_Text textElement;
    public TMP_Text zombiesRemaining;
    private ZombieSpawner[] spawnPointScripts; // Change the type to ZombieSpawner array

    void Start()
    {
        // Get references to all ZombieSpawner scripts in the scene
        spawnPointScripts = FindObjectsOfType<ZombieSpawner>();

        UpdateWaveText();
        UpdateZombiesRemaining();
    }

    void Update()
    {
        UpdateWaveText();
        UpdateZombiesRemaining();
    }

    void UpdateWaveText()
    {
        if (textElement != null && spawnPointScripts != null && spawnPointScripts.Length > 0)
        {
            // Use the first ZombieSpawner script to get the current wave
            int waveValue = ZombieSpawner.currentWave;
            textElement.text = "Wave " + waveValue;
        }
        else
        {
            Debug.LogWarning("Text element or ZombieSpawner scripts are not assigned or not found.");
        }
    }

    void UpdateZombiesRemaining()
    {
        int remainingZombies = 0;

        // Sum up remaining zombies from all ZombieSpawner scripts
        foreach (var spawner in spawnPointScripts)
        {
            remainingZombies += spawner.remainingZombies;
        }

        // Update the zombies remaining text
        zombiesRemaining.text = "Zoms Remaining: " + remainingZombies;
    }
}
