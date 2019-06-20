using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleObject : MonoBehaviour
{
    [SerializeField]
    private string name;

    public string GetName()
    {
        return name;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")   // Player Collect tuşu ile objeyi envantere alıyor.
        {
            if (Input.GetKeyDown(GameManager.GetCollectKeyCode()))
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
