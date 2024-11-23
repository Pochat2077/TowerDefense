using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    
    [SerializeField]
    private GameObject boomFxPref;
    [SerializeField]
    private EnemyData enemyData;
    private Vector3 finishPoint;
    [SerializeField]
    private NavMeshAgent navMesh;
    private int DeathCoins = 10;
    private int health;
   
   
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
    public void EnemyDamage(int damage)
    {
       health -= damage;
        if(health <= 0 )
        {
            
            
            Instantiate(boomFxPref, new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), Quaternion.Euler(-90f, 0f, 0f));
            
            Destroy(gameObject);
        }
    }
    public void GetDamage()
    {
        
    }
}
