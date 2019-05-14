using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleObject : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Objeyi Aldın.");
                AddInventory();
                Destroy(gameObject);
            }
        }
    }

    protected virtual void AddInventory()
    {
        FindObjectOfType<GameManager>().AddInventoryItem(this);
    }
}
