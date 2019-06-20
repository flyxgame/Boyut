using UnityEngine;

[System.Serializable]
public class KeyData
{
    public bool[] inInventory;
    public int[] keyNo;
    public float[,] position;

    public KeyData(Key[] keyList)
    {
        int index = 0, count = keyList.Length;

        inInventory = new bool[count];
        keyNo = new int[count];
        position = new float[count, 3];

        for (index = 0; index < count; index++)
        {
            inInventory[index] = keyList[index].GetInInventory();
            keyNo[index] = keyList[index].GetKeyNo();

            if (!inInventory[index]) // object is invalid?
            {
                position[index, 0] = keyList[index].gameObject.transform.position.x;
                position[index, 0] = keyList[index].gameObject.transform.position.y;
                position[index, 2] = keyList[index].gameObject.transform.position.z;
            }

        }

    }
}
