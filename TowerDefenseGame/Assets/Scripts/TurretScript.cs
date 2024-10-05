using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurretScript : MonoBehaviour
{ 
    [Header("Bullet settings")]
    [SerializeField]
    private GameObject bulletPref;
    [SerializeField]
    private Transform[] gunBarrel;
    [SerializeField]
    private float rechargeTime = 1f;
    private bool isSecondBarrel;
    private bool canShoot = true;
    private Transform target;
    [SerializeField]
    private float range = 3f;

    private List<Transform> targetsInRange = new List<Transform>();

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, range);
    }
    private Transform FindTarget()
    {
        if(targetsInRange == null) return null;
        Transform newTarget = targetsInRange.First();
        RemoveNullObjects();

        foreach ( Transform t in targetsInRange)
        {  
            float distanceToEnemy = Vector3.Distance(transform.position, t.position);
            float distanceToPrevEnemy = Vector3.Distance(transform.position, newTarget.position);
            if(distanceToEnemy < distanceToPrevEnemy)
            {
                
                newTarget = t;
            }
            
        }
       return newTarget;
    }
    private void RemoveNullObjects()
    {
        var nullObjects = new List<Transform>();
        foreach(Transform t in targetsInRange)
        {
            if(t == null)
            {
                nullObjects.Add(t);
            }
        }
        foreach(Transform t in nullObjects)
        {
            targetsInRange.Remove(t);
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Enemy")
        {
            targetsInRange.Add(col.transform);
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if(col.tag == "Enemy")
        {
            targetsInRange.Remove(col.transform);
        }
    }
    private void OnTriggerStay(Collider col)
    {
        if(col.tag == "Enemy")
        {
           target = FindTarget();
        }
    }
    private void Start()
    {
        //InvokeRepeating("FindTarget", 0f, 0.3f);
    }

    private void Update()
    {
        if(target != null)
        {
            transform.LookAt(target);
        }
    }
}
