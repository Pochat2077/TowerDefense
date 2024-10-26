using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    private float speed = 2f;
    private Transform target;
    [SerializeField] 
    private int damage = 10;
    private uint health;
    public Transform Target 
    {
        set
        {
            target = value;
            TakeForce(target);
        }
    }

    private void Awake()
    {

    }
    private void Update()
    {

    }
   /* public void SetTarget(Transform newTarget)
    {
        target = newTarget;
        TakeForce(target);
    }*/


    // Start is called before the first frame update
    private void TakeForce(Transform target)
    {
        Vector3 dir = target.position - transform.position;
        rb.AddForce(dir * speed, ForceMode.Impulse);
    }
    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Ground")
        {
            Destroy(gameObject);
        }
        if(col.tag == "Enemy")
        {
            col.GetComponent<Enemy>().EnemyDamage(damage);
            Destroy(gameObject);
            
        }
    }
}
