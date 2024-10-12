using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurretScript : MonoBehaviour
{ 
    [Header("Shot settings")]
    [SerializeField]
    private GameObject bulletPref;
    [SerializeField]
    private Transform[] gunBarrel;
    [SerializeField]
    private float rechargeTime = 1f;
   
   
    private int currentBarrelIndex = 0;
    private Transform target;
    [SerializeField]
    private float range = 3f;

    private List<Transform> targetsInRange = new List<Transform>();

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, range);
    }
    private void Update()
    {
        if(target != null)
        {
            transform.LookAt(target);
           
        }
    }
    private IEnumerator Shoot( Transform currentTarget)
    {
        while(currentTarget !=null)
        {
        yield return new WaitForSeconds(rechargeTime);
        GameObject bullet = Instantiate(bulletPref, gunBarrel [currentBarrelIndex]);
        bulletPref.transform.parent = null;

        BulletScript bulletscript = bullet.GetComponent<BulletScript>();
        bulletscript.Target = target;

        currentBarrelIndex++;
        if(currentBarrelIndex == gunBarrel.Length)
        {
            currentBarrelIndex = 0;
        }
        }

       

    }
    private Transform FindTarget()
    {
        if(targetsInRange == null) return null;
        RemoveNullObjects();
        Transform newTarget = targetsInRange.First();
        

        foreach ( Transform t in targetsInRange)
        {  
            float distanceToEnemy = Vector3.Distance(transform.position, t.position);
            float distanceToPrevEnemy = Vector3.Distance(transform.position, newTarget.position);
            if(distanceToEnemy < distanceToPrevEnemy)
            {
                
                StopCoroutine(Shoot( newTarget));
                StartCoroutine(Shoot( t));
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
            if(targetsInRange == null)
            {
                StartCoroutine(Shoot( col.transform));
            }
            
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

    
}
