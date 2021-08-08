using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyPrefab;
    public int enemyCount = 1;
    public int waveNumber = 1;
    public GameObject powerUp;
    void Start()
    {
        // Instantiate(enemy, SpawnObject(), enemy.transform.rotation);
    SpawnEnemyObject(1);
  
    Instantiate(powerUp, SpawnObject(), powerUp.transform.rotation);
    
    

    }

    // Update is called once per frame
    void Update()
    {
       enemyCount = FindObjectsOfType<EnemyScript>().Length;
       if (enemyCount == 0)
       {
           waveNumber++;
           SpawnEnemyObject(waveNumber);
           Instantiate(powerUp, SpawnObject(), powerUp.transform.rotation);
       }
    }

    void SpawnEnemyObject(int numEnemy)
    {
        // Set the numEnemy as a parameter to control how many time Instantiate is call
        for (int i = 0; i < numEnemy; i++)
        {
            Instantiate(enemyPrefab, SpawnObject(), enemyPrefab.transform.rotation);
            
        }
    }
    
    
    
    
    private Vector3 SpawnObject()
    {
        float spawnPosX = Random.Range(-9.0f, 9.0f);
        float spawnPosZ = Random.Range(-9.0f, 9.0f);
        Vector3 spawnRange = new Vector3(spawnPosX, 0, spawnPosZ);
        return spawnRange;
    }
}
