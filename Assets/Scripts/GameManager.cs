using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
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
    private UnityStandardAssets.Characters.FirstPerson.FirstPersonController characterScript;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Door[] doors;

    [SerializeField]
    private CollectibleObject[] inventoryObjects;

    [SerializeField]
    private Key[] keys;

    [SerializeField]
    private Newspaper[] newspapers;

    //--------------------------------------------------------------------------------------

    [SerializeField]
    private int saveTime = 300; //

    private InventorySystem inventory;

    private BatteryStatus batteryStatus;

    private int i, j; // loop variables;

    private void Start()
    {
        InitializeVariables();
        LoadGame();
    }

    private void InitializeVariables()
    {
        inventory = GetComponent<InventorySystem>();
        batteryStatus = characterScript.GetComponent<BatteryStatus>();
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

    public int GetCurrentKeyNo() // mevcut anahtarı getir.
    {
        return inventory.GetCurrentKey();
    }

    void Update()
    {
        CheckInputs();
    }

    void CheckInputs()
    {
        // Show inventory, newspapers and keys.
        if (Input.GetKeyDown(showKeysKeyCode))
        {
            inventory.ListKeys();
        }
        if (Input.GetKeyDown(showInventoryKeyCode))
        {
            inventory.ListMyObjects();
        }
        if (Input.GetKeyDown(showNewspapersKeyCode))
        {
            inventory.ListNewspapers();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            SaveGame();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            LoadGame();
        }
    }

    // Save and Load 
    public void SaveGame()
    {
        KeyData keyData = new KeyData(keys);
        SaveSystem.SaveKeyData(keyData); //Key Data saving.

        float[] playerPosition = { characterScript.transform.position.x, characterScript.transform.position.y, characterScript.transform.position.z };
        float[] playerRotation = { characterScript.transform.rotation.eulerAngles.x, characterScript.transform.rotation.eulerAngles.y, characterScript.transform.rotation.eulerAngles.z };

        PlayerData playerData = new PlayerData(playerPosition, playerRotation, batteryStatus.GetBatteryStatus()); // Player Data saving.

        SaveSystem.SavePlayerData(playerData); //Player Data saving.

        NewspaperData newspaperData = new NewspaperData(newspapers);

        SaveSystem.SaveNewspaperData(newspaperData); //Newspaper Data saving.
    }

    public void LoadGame()
    {
        KeyData keyData = SaveSystem.LoadKeyData();

        PlayerData playerData = SaveSystem.LoadPlayerData();

        NewspaperData newspaperData = SaveSystem.LoadNewspaperData();

        for (i = 0; i < keyData.keyNo.Length; i++)
        {
            keys[i].SetInInventory(keyData.inInventory[i]);
            if (keyData.inInventory[i]) // envanterde olan anahtarların envantere yüklenmesi ve sahneden gizlenmesi
            {
                Key key = new Key(keyData.keyNo[i], true);
                inventory.AddKey(key); // envantere tekrar ekliyoruz.
                keys[i].gameObject.SetActive(false); // destroy etmiyoruz sonradan ihtiyacımız olabilir.
            }
        }

        for (i = 0; i < newspaperData.newspaperId.Length; i++)
        {
            newspapers[i].SetInInventory(newspaperData.inInventory[i]);
            if (newspaperData.inInventory[i]) // envanterde olan newspaperlerin envantere yüklenmesi ve sahneden gizlenmesi
            {
                Newspaper newspaper = new Newspaper(newspapers[i].GetNewspaperId(), newspapers[i].GetDescription(), true);
                inventory.AddNewspaper(newspaper); // envantere tekrar ekliyoruz.
                newspapers[i].gameObject.SetActive(false); // sahneden gizliyoruz.
            }
        }

        //Batarya son durumunun yüklenmesi.
        batteryStatus.SetBatteryStatus(playerData.batteryStatus);

        //Karakterin son pozisyonunun ve rotasyonunun yüklenmesi.
        Vector3 playerPos = new Vector3(playerData.position[0], playerData.position[1], playerData.position[2]);
        Vector3 playerRot = new Vector3(playerData.rotation[0], playerData.rotation[1], playerData.rotation[2]);

        player.GetComponent<CharacterController>().enabled = false;  // değişiklik yapabilmek için character controller'ı devre dışı bırakmamız gerekiyor.

        player.transform.position = playerPos; //changing player position;

        player.transform.rotation = Quaternion.Euler(playerRot); // Bir bug'dan ötürü rotate edilmiyor to do: MERT

        player.GetComponent<CharacterController>().enabled = true; // tekrar controller'ı aktif hale getirdik.


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
