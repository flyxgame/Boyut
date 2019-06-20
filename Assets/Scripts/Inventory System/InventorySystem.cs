using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    List<CollectibleObject> myObjects = new List<CollectibleObject>();
    List<Key> keys = new List<Key>();
    List<Newspaper> newspapers = new List<Newspaper>();

    int currentKey;

    private void Update()
    {
        //Basic key change inputs
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

    private void ChangeKey(int index) // pil değiştirme
    {
        Debug.Log("Current Key:" + keys[index].GetKeyNo());
        currentKey = index;
    }

    public void AddObject(CollectibleObject obj) // Gelen objeyi envantere ekleme.
    {
        myObjects.Add(obj);
    }

    public void AddKey(Key key) //Anahtar listesine gelen anahtarı ekleme.
    {
        keys.Add(key);
    }

    public void AddNewspaper(Newspaper newspaper) // Gazete listesine gelen gazeteyi ekleme.
    {
        newspapers.Add(newspaper);
    }

    public void ListNewspapers() // Gazeteleri listeleme
    {
        foreach (var newspaper in newspapers)
        {
            Debug.Log(newspaper.name);
        }
    }

    public void ListKeys() // Anahtarları Listele.
    {
        foreach (var key in keys)
        {
            Debug.Log(key.GetKeyNo());
        }
    }

    public void ListMyObjects() // Envanterdeki Objeleri Listele.
    {
        foreach (var key in myObjects)
        {
            Debug.Log(key);
        }
    }

    public int GetCurrentKey() // Kullanılan anahtarın numarasını getir.
    {
        return keys[currentKey].GetKeyNo();
    }

    // List SET GET Methods

    public List<Key> GetKeyList()
    {
        return keys;
    }
    
    public List<CollectibleObject> GetMyObjects()
    {
        return myObjects;
    }

    public List<Newspaper> GetNewspapers()
    {
        return newspapers;
    }

    public void SetKeyList(List<Key> keyList)
    {
        keys = keyList;
    }
    
    public void SetMyObjectList(List<CollectibleObject> objectList)
    {
        myObjects = objectList;
    }
    
    public void SetNewspaperList(List<Newspaper> newspaperList)
    {
        newspapers = newspaperList;
    }
}
