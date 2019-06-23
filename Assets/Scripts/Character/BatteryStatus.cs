using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class BatteryStatus : MonoBehaviour
{
    [SerializeField]
    private float batteryStatus = 25;

    [SerializeField]
    private float reductionPerSeconds = 0.01f; // bataryanın 1 saniyede azalma miktarı

    [SerializeField]
    private Material chargeMaterial;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private float chargingControlWeight = 1f;

    [SerializeField]
    private bool flashLightIsOn = true; // fener ışığının açık olup olmadığını belirten değişken.

    private bool isReducing = false; // pil azalması aktif deaktif 


    private void Update()
    {
        ChargeSettings();
        GetInput();

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

    void ChargeSettings()
    {
        chargeMaterial.mainTextureOffset = new Vector2(0, 1.5f - (batteryStatus / 10 * 0.05f));
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

    void GetInput()
    {
        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("chr_walk", true);

        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("chr_walk", false);
            animator.SetBool("chr_lookCharge", false);
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("chr_run", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetBool("chr_run", false);
        }
        if (Input.GetMouseButton(1) && !Input.GetKey(KeyCode.LeftShift))
        {
            if (!animator.GetBool("chr_lookCharge"))
            {
                animator.SetLayerWeight(1, chargingControlWeight);
                animator.SetBool("chr_lookCharge", true);
            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            animator.SetBool("chr_lookCharge", false);
        }
    }
}
