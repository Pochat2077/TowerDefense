using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance;
    [SerializeField]
    private LayerMask LayerMask;
    
    [SerializeField] 
    private Color hoverColor;
    [SerializeField]
    private Color startColor;
    private GameObject selectedNode;
    private TurretData currentTurretData;

    private bool canBuild;
    
    // Start is called before the first frame update
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//промінь з камери в позирцію мишки
        

        if(Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, LayerMask))
        {
            if(hit.collider.tag == "Node" && canBuild)
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
            selectedNode.GetComponent<NodeBuildSettings>().StartBuild(currentTurretData.turretPref,currentTurretData.spawnpoint , currentTurretData.cost, currentTurretData.index);
            
            canBuild = false;
            InterstitialAd.Instance.TowerWasBuilt();
        }
    }
    public void SetBuildTurret(TurretData turretData)
    {
        canBuild = true;
        currentTurretData = turretData;
        
    }
}
