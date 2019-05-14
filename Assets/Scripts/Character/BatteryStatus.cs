using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryStatus : MonoBehaviour
{
    [SerializeField]
    private float batteryStatus = 100;

    [SerializeField]
    private float reductionPerSeconds = 0.01f; // in 1 seconds

    [SerializeField]
    private bool flashLightIsOn = true;

    private bool isReducing = false;

    
    private void Update()
    {
        if (!isReducing && flashLightIsOn)
        {
            StartCoroutine(ReduceBattery());
        }
    }

    private IEnumerator ReduceBattery()
    {
        isReducing = true;

        batteryStatus -= reductionPerSeconds;
        yield return new WaitForSeconds(1f);

        isReducing = false;
    }

    public void AddBattery(float value)
    {
        batteryStatus = Mathf.Clamp(batteryStatus + value, 0, 100);
    }

    public void OffFlashLight()
    {
        flashLightIsOn = false;
    }

    public void OnFlashLight()
    {
        flashLightIsOn = true;
    }
}
