using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private float countdown = 5f;
    [SerializeField]
    private float timeBetweenSpawnEnemy = 1f;
    
    private int waveNumber = 1;
    private int EnemyCount = 1;
    
    private void Start()
    {
        //InvokeRepeating("SpawnEnemy", 1f, 1f);
        StartCoroutine(SpawnWave());
    }
    private IEnumerator SpawnWave()
    {
       yield return new WaitForSeconds(countdown);
       
       for (int i = 0; i < EnemyCount; i++)
       {
        GameObject obj =  Instantiate(enemyPrefab, transform.position, Quaternion.identity);
       obj.transform.parent = transform;
       yield return new WaitForSeconds(timeBetweenSpawnEnemy);
       }
       waveNumber++;
       if(EnemyCount < 15)
       {
        EnemyCount++;
       }
       StartCoroutine(SpawnWave());
       
    }
    
}
