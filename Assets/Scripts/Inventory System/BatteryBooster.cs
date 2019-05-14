using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryBooster : CollectibleObject
{
    [SerializeField]
    private float batteryValue = 20;

    protected override void AddInventory()
    {
        FindObjectOfType<GameManager>().AddBattery(batteryValue);  
    }
}
