using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryStatus : MonoBehaviour
{
    [SerializeField]
    private float batteryStatus = 25;

    [SerializeField]
    private float reductionPerSeconds = 0.01f; // bataryanın 1 saniyede azalma miktarı

    [SerializeField]
    private bool flashLightIsOn = true; // fener ışığının açık olup olmadığını belirten değişken.

    private bool isReducing = false; // pil azalması aktif deaktif 


    private void Update()
    {
        if (!isReducing && flashLightIsOn) // Azalma aktif ve fener açık ise bataryayı azalt.
        {
            StartCoroutine(ReduceBattery());
        }
    }

    private IEnumerator ReduceBattery() // her saniye bataryayı azaltan thread.
    {
        isReducing = true;

        batteryStatus -= reductionPerSeconds;
        yield return new WaitForSeconds(1f);

        isReducing = false;
    }

    public void AddBattery(float value) // Batarya miktarı ekle
    {
        batteryStatus = Mathf.Clamp(batteryStatus + value, 0, 100);
    }

    public float GetBatteryStatus() // Güncel batarya miktarını getir.
    {
        return batteryStatus;
    }

    public void SetBatteryStatus(float value) // Batarya miktarını değiştir.
    {
        batteryStatus = Mathf.Clamp(value, 0, 100);
    }

    // Feneri açma kapama fonksiyonları.
    public void OffFlashLight()
    {
        flashLightIsOn = false;
    }

    public void OnFlashLight()
    {
        flashLightIsOn = true;
    }
}
