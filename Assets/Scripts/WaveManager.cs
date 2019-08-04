using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject greenSmall;
    public GameObject greenMedium;
    public GameObject greenLarge;
    public GameObject redSmall;
    public GameObject redMedium;
    public GameObject redLarge;
    public GameObject blueSmall;
    public GameObject blueMedium;
    public GameObject blueLarge;

    public int greenSmallPercentage;
    public int greenMediumPercentage;
    public int greenLargePercentage;

    public int blueSmallPercentage;
    public int blueMediumPercentage;
    public int blueLargePercentage;

    public int redSmallPercentage;
    public int redMediumPercentage;
    public int redLargePercentage;

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

    public void SpawnObject(ColorState color, GameObject spawnPoint, GameObject enemyFab)
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
                switch (Mathf.Floor((i % 3)))
                {
                    case 0:
                        SpawnObject(ColorState.GREEN, GetRandomSpawnPoint(), GetGreenEnemy());
                        break;
                    case 1:
                        SpawnObject(ColorState.BLUE, GetRandomSpawnPoint(), GetBlueEnemy());
                        break;
                    case 2:
                        SpawnObject(ColorState.RED, GetRandomSpawnPoint(), GetRedEnemy());
                        break;
                }
                // SpawnObject(ColorState.GREEN, GetRandomSpawnPoint());
            }
            waveNumber++;
            waveMod += 0.1f;
            UpdateWaveVariables();
            //Debug.Log("Wave " + waveNumber + " completed");
            //Debug.Log("New Wave Delay: " + spawnDelay.ToString());
            //Debug.Log("New Enemies Per Wave: " + enemiesPerWave.ToString());
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

    private GameObject GetRedEnemy()
    {
        int secondMax = redSmallPercentage + redMediumPercentage;
        int thirdMax = secondMax + redLargePercentage;
        int chance = Random.Range(1, 100);

        if (chance <= redSmallPercentage)
        {
            return redSmall;
        }
        else if (chance > redSmallPercentage && chance <= secondMax)
        {
            return redMedium;
        }
        else
        {
            return redLarge;
        }

        /*
        switch (Random.Range(0,2))
        {
            case 0:
                return redSmall;
            case 1:
                return redMedium;
            case 2:
                return redLarge;
            default:
                return redSmall;
        }
        */
    }

    private GameObject GetBlueEnemy()
    {
        int secondMax = blueSmallPercentage + blueMediumPercentage;
        int thirdMax = secondMax + blueLargePercentage;
        int chance = Random.Range(1, 100);

        if (chance <= blueSmallPercentage)
        {
            return blueSmall;
        }
        else if (chance > blueSmallPercentage && chance <= secondMax)
        {
            return blueMedium;
        }
        else
        {
            return blueLarge;
        }
        /*
        switch (Random.Range(0,2))
        {
            case 0:
                return blueSmall;
            case 1:
                return blueMedium;
            case 2:
                return blueLarge;
            default:
                return blueSmall;
        }
        */
    }

    private GameObject GetGreenEnemy()
    {
        int secondMax = greenSmallPercentage + greenMediumPercentage;
        int thirdMax = secondMax + greenLargePercentage;
        int chance = Random.Range(1, 100);

        if (chance <= greenSmallPercentage)
        {
            return greenSmall;
        }
        else if (chance > greenSmallPercentage && chance <= secondMax)
        {
            return greenMedium;
        }
        else
        {
            return greenLarge;
        }
        /*
        switch (Random.Range(0,2))
        {
            case 0:
                return greenSmall;
            case 1:
                return greenMedium;
            case 2:
                return greenLarge;
            default:
                return greenSmall;
        }
        */
    }
}
