using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    [SerializeField]
    private GameObject turretPref;
    [SerializeField] 
    private Color hoverColor;
    [SerializeField]
    private Color startColor;
    private GameObject selectedNode;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//промінь з камери в позирцію мишки
        

        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            if(hit.collider.tag == "Node")
            {
                selectedNode = hit.collider.gameObject;
                selectedNode.GetComponent<MeshRenderer>().material.color = hoverColor;
            }
            else 
            {
                if(selectedNode !=null)
                {
                    selectedNode.GetComponent<MeshRenderer>().material.color = startColor;
                }
                

            }
        }
        if(Input.GetMouseButtonDown(0))
        {
            selectedNode.GetComponent<NodeBuildSettings>().StartBuild(turretPref, 0.35f);
        }
    }
}
