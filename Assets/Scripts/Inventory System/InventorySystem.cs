using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    List<CollectibleObject> myObjects = new List<CollectibleObject>();
    List<Key> keys = new List<Key>();

    int currentKey;

    void Start()
    {
        LoadInventory();

    }

    private void LoadInventory()
    {
        //player prefs events..

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeKey(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeKey(1);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeKey(2);
        }

        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ChangeKey(3);
        }
    }

    private void ChangeKey(int index)
    {
        Debug.Log("Current Key:" + keys[index].GetKeyNo());
        currentKey = index;
    }

    public void AddObject(CollectibleObject obj)
    {
        myObjects.Add(obj);
    }
    public void AddKey(Key key)
    {
        keys.Add(key);
    }

    public void ListKeys()
    {
        foreach (var key in keys)
        {
            Debug.Log(key.GetKeyNo());
        }
    }

    public void ListMyObjects()
    {
        foreach (var key in myObjects)
        {
            Debug.Log(key);
        }
    }
    public int GetCurrentKey()
    {
        return keys[currentKey].GetKeyNo();
    }
}
