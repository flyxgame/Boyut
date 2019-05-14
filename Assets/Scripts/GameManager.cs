using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{ 

    [Header("Controls")]

    [SerializeField]
    private KeyCode interactionKey;

    [SerializeField]
    private KeyCode CollectKey;

    //--------------------------------------------------------------------------------------
    [Header("Game Objects")]

    [SerializeField]
    private UnityStandardAssets.Characters.FirstPerson.FirstPersonController character;
    //--------------------------------------------------------------------------------------

    private InventorySystem inventory;

    private BatteryStatus batteryStatus;


    // Start is called before the first frame update
    private void Start()
    {
        inventory = GetComponent<InventorySystem>();
        batteryStatus = character.GetComponent<BatteryStatus>();

    }

    public void AddInventoryItem(CollectibleObject collectibleObject)
    {
        inventory.AddObject(collectibleObject);
    }

    public void AddKey(Key key)
    {
        inventory.AddKey(key);
    }

    public void AddBattery(float value)
    {
        Debug.Log("Battery Boosted:+" + value);

        batteryStatus.AddBattery(value);
    }

    public int GetCurrentKeyNo()
    {
        return inventory.GetCurrentKey();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            inventory.ListKeys();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            inventory.ListMyObjects();
        }
    }
}
