using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject enemyFab;
    public bool stopSpawning;
    public float maxWaveSpawnInterval; // max and min for speeding up wave generation as time passes
    public float minWaveSpawnInterval;
    public float waveSpawnModifier; // the modifier that scales the time difference between waves (lower than 1, preferably high i.e 0.99f)
    private float waveMod; //scales on waves, not a fixed value
    private float spawnDelay; // tracks the current time between waves
    // private float spawnTime; // time before the first wave spawns
    public float maxEnemiesPerWave; // max and min of num of enemies between waves
    public float minEnemiesPerWave;
    public float enemySpawnModifier; // modifier that scales how fast the enemies ramp between waves (higher than 1)
    private float enemiesPerWave;
    private int waveNumber;
    

    private GameObject[] spawnPoints;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnDelay = maxWaveSpawnInterval;
        enemiesPerWave = minEnemiesPerWave;
        if (waveSpawnModifier > 1f)
        {
            waveSpawnModifier = 0.99f;
        }
        if (enemySpawnModifier < 1f)
        {
            enemySpawnModifier = 1.01f;
        }
        
        waveNumber = 0;
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        waveMod = 1f;

        Debug.Log("Spawn Points: " + spawnPoints.ToString() + " spawn length: " + spawnPoints.Length.ToString());

        StartCoroutine(SpawnWave());
        Debug.Log("ColorState print: " + ColorState.BLUE.ToString());
        // InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    public void SpawnObject(ColorState color, GameObject spawnPoint)
    {
        // will change this to be spawnPoint.position and rotation instead of `this`
        // also might need to make handling to spawn enemies of a specific color
        GameObject enemy = Instantiate(enemyFab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        enemy.tag = color.ToString();
    }

    IEnumerator SpawnWave()
    {
        for (;;)
        {
            for (int i = 0; i < Mathf.Ceil(enemiesPerWave); i++)
            {
                SpawnObject(ColorState.GREEN, GetRandomSpawnPoint());
            }
            waveNumber++;
            waveMod += 0.1f;
            UpdateWaveVariables();
            Debug.Log("Wave " + waveNumber + " completed");
            Debug.Log("New Wave Delay: " + spawnDelay.ToString());
            Debug.Log("New Enemies Per Wave: " + enemiesPerWave.ToString());
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    public void UpdateWaveVariables()
    {
        float waveDifference = spawnDelay * (waveSpawnModifier / waveMod);
        float enemyDifference = enemiesPerWave * enemySpawnModifier;

        if (enemiesPerWave >= maxEnemiesPerWave)
        {
            enemiesPerWave = maxEnemiesPerWave;
        }
        else
        {
            enemiesPerWave = enemyDifference;
        }

        if (spawnDelay <= minWaveSpawnInterval)
        {
            spawnDelay = minWaveSpawnInterval;
        }
        else
        {
            spawnDelay = waveDifference;
        }
    }

    private GameObject GetRandomSpawnPoint()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Length)];
    }
}
