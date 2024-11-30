using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonShop : MonoBehaviour
{
    [SerializeField]
    private Text costText;
    [SerializeField]
    private Text CountText;
    [SerializeField]
    private Image image;
    [SerializeField]
    private TurretData turretdata;
    [SerializeField]
    private Button button;

    private int turretCount;


    // Start is called before the first frame update
    private void Start()
    {
        Init();
        
    }

    private void Init()
    {
        var buildManager = BuildManager.Instance;
        
        costText.text = turretdata.cost.ToString();
        image.sprite = turretdata.icon;
        turretCount = turretdata.maxCount;
        CountText.text = $"{turretCount}/{turretdata.maxCount}";

        buildManager.onBuild += ChangeCount;

        button.onClick.AddListener(() => buildManager.SetBuildTurret(turretdata));
    }

    // Update is called once per frame
   private void ChangeCount()
   {
    turretCount--;
     CountText.text = $"{turretCount}/{turretdata.maxCount}";
     if(turretCount <= 0)
     {
        button.interactable = false;
     }
   }
   
}
