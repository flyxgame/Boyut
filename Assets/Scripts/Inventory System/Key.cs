using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : CollectibleObject
{
    [SerializeField]
    private int keyNo;

    private bool inInventory; // envanterde mi yoksa sahnede mi?

    public int GetKeyNo()
    {
        return keyNo;
    }

    public bool GetInInventory()
    {
        return inInventory;
    }

    public void SetInInventory(bool state)
    {
        inInventory = state;
    }

    public Key(int keyNo, bool inInventory)
    {
        this.keyNo = keyNo;
        this.inInventory = inInventory;
    }

    protected override void AddInventory()
    {
        inInventory = true;
        FindObjectOfType<GameManager>().AddKey(this);
    }

}
