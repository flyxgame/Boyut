
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{

    public static void SavePlayerData(PlayerData data)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerdata.save");
        Debug.Log(Application.persistentDataPath);
        bf.Serialize(file, data);
        file.Close();

        Debug.Log("Game saved.");
    }

    public static void SaveKeyData(KeyData data)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/keydata.save");
        Debug.Log(Application.persistentDataPath);
        bf.Serialize(file, data);
        file.Close();

        Debug.Log("Game saved.");
    }

    public static void SaveNewspaperData(NewspaperData data)
    {

    }

    public static KeyData LoadKeyData()
    {
        if (File.Exists(Application.persistentDataPath + "/keydata.save")) // daha önce kaydedilmiş mi
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/keydata.save", FileMode.Open);
            KeyData data = bf.Deserialize(file) as KeyData;
            file.Close();

            Debug.Log("Game Loaded");

            return data;
        }
        else
        {
            Debug.Log("No game saved!");
            return null;
        }

    }

    public static PlayerData LoadPlayerData()
    {
        if (File.Exists(Application.persistentDataPath + "/playerdata.save")) // daha önce kaydedilmiş mi
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerdata.save", FileMode.Open);
            PlayerData data = bf.Deserialize(file) as PlayerData;
            file.Close();

            Debug.Log("Game Loaded");

            return data;

        }
        else
        {
            Debug.Log("No game saved!");
            return null;
        }
    }
}
