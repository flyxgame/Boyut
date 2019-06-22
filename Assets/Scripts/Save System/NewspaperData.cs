using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NewspaperData
{
    public bool[] inInventory;
    public int[] newspaperId;
    public float[,] position;
    public string[] description;

    public NewspaperData(Newspaper[] newspaperList)
    {
        int index = 0, count = newspaperList.Length;

        inInventory = new bool[count];
        newspaperId = new int[count];
        position = new float[count, 3];
        description = new string[count];

        for (index = 0; index < count; index++)
        {
            inInventory[index] = newspaperList[index].GetInInventory();
            newspaperId[index] = newspaperList[index].GetNewspaperId();
            description[index] = newspaperList[index].GetDescription();

            if (!inInventory[index])
            {
                position[index, 0] = newspaperList[index].gameObject.transform.position.x;
                position[index, 0] = newspaperList[index].gameObject.transform.position.y;
                position[index, 2] = newspaperList[index].gameObject.transform.position.z;
            }
        }
    }
}
