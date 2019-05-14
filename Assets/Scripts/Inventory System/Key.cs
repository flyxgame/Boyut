using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : CollectibleObject
{
    [SerializeField]
    private int keyNo;

    public int GetKeyNo()
    {
        return keyNo;
    }

    protected override void AddInventory()
    {
        FindObjectOfType<GameManager>().AddKey(this);
    }

}
