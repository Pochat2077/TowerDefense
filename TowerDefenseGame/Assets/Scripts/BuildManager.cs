using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    [SerializeField]
    private LayerMask LayerMask;
    [SerializeField]
    private GameObject turretPref;
    [SerializeField] 
    private Color hoverColor;
    [SerializeField]
    private Color startColor;
    private GameObject selectedNode;

    private bool canBuild;
    private int turrertIndex, cost;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//промінь з камери в позирцію мишки
        

        if(Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, LayerMask))
        {
            if(hit.collider.tag == "Node")
            {
                var node = hit.collider.GetComponent<NodeBuildSettings>();
                if(node.structure == null)
                {
                 selectedNode = hit.collider.gameObject;
                 selectedNode.GetComponent<MeshRenderer>().material.color = hoverColor;
                }
            }
            else 
            {
                if(selectedNode !=null)
                {
                    selectedNode.GetComponent<MeshRenderer>().material.color = startColor;
                    selectedNode = null;
                }
                

            }
        }
        if(Input.GetMouseButtonDown(0) && selectedNode != null)
        {
            selectedNode.GetComponent<NodeBuildSettings>().StartBuild(turretPref, 0.35f);
        }
    }
}
