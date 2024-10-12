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
        if(col.tag == "Enemy")
        {
            Destroy(gameObject);
            
        }
    }
}
