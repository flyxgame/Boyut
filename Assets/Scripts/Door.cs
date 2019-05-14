using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private int keyNo;
    [SerializeField]
    private bool isOn = false;

    [SerializeField]
    private float openDoorZRotation;

    [SerializeField]
    private float closeDoorZRotation;

    [SerializeField]
    private float openCloseTime = 1f;

    private GameManager gameManager;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                OpenTheDoor();
            }
        }
    }

    private void OpenTheDoor()
    {
        if (gameManager.GetCurrentKeyNo() == keyNo)
        {
            if (!isOn)
            {
                isOn = true;
                StartCoroutine(Open());
                Debug.Log("Door is Open.");
            }
            else
            {
                StartCoroutine(Close());
                isOn = false;
                Debug.Log("Door is Close.");
            }
        }
        else
        {
            Debug.Log("Wrong Key!");
        }
    }
    private IEnumerator Open()
    {
        if (openDoorZRotation > closeDoorZRotation)
        {
            for (int i = 0; i < Mathf.Abs(openDoorZRotation - closeDoorZRotation)/2; i++)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 2);
                yield return new WaitForSeconds(0.000000000001f);
            }
        }
        else
        {
            for (int i = 0; i < Mathf.Abs(openDoorZRotation - closeDoorZRotation)/2; i++)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z - 2);   //...rotate the object.

                yield return new WaitForSeconds(0.00000000000001f);
            }
        }
    }

    private IEnumerator Close()
    {
        if (openDoorZRotation > closeDoorZRotation)
        {
            for (int i = 0; i < Mathf.Abs(openDoorZRotation - closeDoorZRotation)/2; i++)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z - 2);
                yield return new WaitForSeconds(0.00000000001f);
            }
        }
        else
        {
            for (int i = 0; i < Mathf.Abs(openDoorZRotation - closeDoorZRotation)/2; i++)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 2);   //...rotate the object.

                yield return new WaitForSeconds(0.0000000001f);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
