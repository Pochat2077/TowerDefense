using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonShop : MonoBehaviour
{
    [SerializeField]
    private Text costText;
    [SerializeField]
    private int cost;
    [SerializeField]
    private int buildIndex;

    [SerializeField]
    private Button button;

    private void Awake()
    {
        costText.text = cost.ToString();
        
    }

    // Start is called before the first frame update
    private void Start()
    {
        costText.text = cost.ToString();
        var buildManager = BuildManager.Instance;
        button.onClick.AddListener(() => buildManager.SetBuildTurret(cost, buildIndex));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
}