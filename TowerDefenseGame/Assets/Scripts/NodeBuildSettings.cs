using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeBuildSettings : MonoBehaviour
{
    public GameObject structure {get; private set;}

    public void StartBuild(GameObject structurePref, float hight)
    {
        if(structure == null)
        {
            Vector3 position = new Vector3(transform.position.x, transform.position.y + hight, transform.position.z);
            structure = Instantiate(structurePref, position, Quaternion.identity);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
