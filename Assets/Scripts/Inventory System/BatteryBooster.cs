using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryBooster : CollectibleObject
{
    [SerializeField]
    private float batteryValue = 10; // Yüzdesel olarak eklenecek batarya miktarı.

    protected override void AddInventory()
    {
        FindObjectOfType<GameManager>().AddBattery(batteryValue);  
    }
}
