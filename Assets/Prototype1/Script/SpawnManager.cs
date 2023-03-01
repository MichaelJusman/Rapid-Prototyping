using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9;

    public int enemyCount;

    public int waveNumber = 1;

    public GameObject[] buffsPrefab;
    public GameObject powerupPrefab;
    public GameObject speedforcePrefab;
    public GameObject healPrefab;

    public GameObject player;
    private Vector3 offset;

    void Start()
    {   
        SpawnEnemyWave(waveNumber);
        InstantiateBuffs();
        offset = transform.position - player.transform.position;
        //Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            InstantiateBuffs();
            //Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }

    }
    void LateUpdate()
    {
        //Set the transform [osition of the camera to that of the player
        transform.position = player.transform.position + offset;

    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0.5f, spawnPosZ);
        return randomPos;
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    void InstantiateBuffs()
    {
        Instantiate(buffsPrefab[Random.Range(0, buffsPrefab.Length)], GenerateSpawnPosition(), buffsPrefab[Random.Range(0, buffsPrefab.Length)].transform.rotation);
    }
}
