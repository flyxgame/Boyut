using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //--- GAME STATES 
    public enum GameState { INTRO, MAINMENU, LOADING, PLAYING, INVENTORY, READING_NEWSPAPER }

    GameState gameState;
    //--------------------------------------------------------------------------------------

    [Header("Controls")]
    private static KeyCode interactionKeyCode = KeyCode.F;
    private static KeyCode collectKeyCode = KeyCode.E;
    private static KeyCode showKeysKeyCode = KeyCode.K;
    private static KeyCode showInventoryKeyCode = KeyCode.I;
    private static KeyCode showNewspapersKeyCode = KeyCode.G;
    //--------------------------------------------------------------------------------------

    [Header("Game Objects")]

    [SerializeField]
    private UnityStandardAssets.Characters.FirstPerson.FirstPersonController character;
    //--------------------------------------------------------------------------------------

    private InventorySystem inventory;

    private BatteryStatus batteryStatus;

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

    void Update()
    {
        if (Input.GetKeyDown(showKeysKeyCode))
        {
            inventory.ListKeys();
        }
        if (Input.GetKeyDown(showInventoryKeyCode))
        {
            inventory.ListMyObjects();
        }
    }

    // Controls Get Methods 
    public static KeyCode GetInteractionKeyCode()
    {
        return interactionKeyCode;
    }

    public static KeyCode GetCollectKeyCode()
    {
        return collectKeyCode;
    }
    // Controls Get Methods End

}
