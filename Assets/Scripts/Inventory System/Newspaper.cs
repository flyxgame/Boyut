using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newspaper : CollectibleObject
{
    // --- Gazete Parçası hakkında bilgilerin yer aldığı değişkenler --- //

    [SerializeField] private string name;

    public string GetName()
    {
        return name;
    }

    protected override void AddInventory()
    {
        FindObjectOfType<InventorySystem>().AddNewspaper(this);
    }
}
