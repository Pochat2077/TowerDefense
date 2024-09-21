using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private EnemyData enemyData;
    private Vector3 finishPoint;
    [SerializeField]
    private NavMeshAgent navMesh;
    private uint health;
   
   private void Awake()
    {
        finishPoint = GameObject.FindGameObjectWithTag("Finish").transform.position; Debug.Log("Ok");
    }

    
    void Start()
    {
        navMesh.destination = finishPoint;
        navMesh.speed = enemyData.speed;
        health = enemyData.maxHealth;
    }
    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Finish")
        {
            Destroy(gameObject);
        }
    }
}
