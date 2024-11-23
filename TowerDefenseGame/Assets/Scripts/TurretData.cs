using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Data", menuName = "ScriptableObjects/TurretData", order = 2)]
public class TurretData : ScriptableObject
{

    public int MaxHealth;
    public int Damage;
    public int index;
    public int cost;
    public int maxCount;
    public float spawnpoint;

    public Sprite icon;

    public GameObject turretPref;



    
}
