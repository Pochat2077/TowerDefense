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

    private void Awake()
    {
        Init();
        
    }

    // Start is called before the first frame update
    private void Start()
    {
        var buildManager = BuildManager.Instance;
        button.onClick.AddListener(() => buildManager.SetBuildTurret(turretdata));
    }

    private void Init()
    {
        costText.text = turretdata.cost.ToString();
        image.sprite = turretdata.icon;
        turretCount = turretdata.maxCount;
        CountText.text = $"{turretdata.maxCount}/{turretCount}";
    }

    // Update is called once per frame
   public void ChangeCount()
   {
    turretCount--;
     CountText.text = $"{turretdata.maxCount}/{turretCount}";
     if(turretCount <= 0)
     {
        button.interactable = false;
     }
   }
   
}
